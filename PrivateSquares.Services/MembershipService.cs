using PrivateSquares.Business.DomainModels;
using PrivateSquares.Business.Extensions;
using PrivateSquares.Data.EntityModels;
using PrivateSquares.Data.Persistences;
using PrivateSquares.Data.Repositories;
using PrivateSquares.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace PrivateSquares.Services
{
    public class MembershipService : IMembershipService
    {
        #region Variables
        private readonly IEntityRepository<User> _userRepository;
        private readonly IEntityRepository<Role> _roleRepository;
        private readonly IEntityRepository<UserRole> _userRoleRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        public MembershipService(IEntityRepository<User> userRepository, IEntityRepository<Role> roleRepository,
        IEntityRepository<UserRole> userRoleRepository, IEncryptionService encryptionService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _encryptionService = encryptionService;
            _unitOfWork = unitOfWork;
        }

        #region IMembershipService Implementation

        public MembershipContext ValidateUser(string username, string password)
        {
            var membershipCtx = new MembershipContext();

            var user = _userRepository.GetSingleByUsername(username);
            if (user != null && isUserValid(user, password))
            {
                var userRoles = GetUserRoles(user.Email);
                membershipCtx.User = user;

                var identity = new GenericIdentity(user.Email);
                membershipCtx.Principal = new GenericPrincipal(
                    identity,
                    userRoles.Select(x => x.Name).ToArray());
            }

            return membershipCtx;
        }
        public User CreateUser(UserView userView)
        {
            var existingUser = _userRepository.GetSingleByUsername(userView.Email);

            if (existingUser != null)
            {
                throw new Exception("Username is already in use");
            }

            var passwordSalt = _encryptionService.CreateSalt();
            Guid Id = Guid.NewGuid();
            var user = new User()
            {
                Email = userView.Email,
                Salt = passwordSalt,
                Password = _encryptionService.EncryptPassword(userView.Password, passwordSalt),
                UserID = Id,
                ApprovedBy = Id,
                VerifiedEmail = false,
                VerifiedPhone = false,
                IsActive = false,
                IsDeleted = false,
                ModifiedOn = DateTime.Now,
                CreatedOn = DateTime.Now
            };

            _userRepository.Add(user);

            _unitOfWork.Commit();

            //if (roles != null || roles.Length > 0)
            //{
            //    foreach (var role in roles)
            //    {
            //        addUserToRole(user, role);
            //    }
            //}

            _unitOfWork.Commit();

            return user;
        }

        public User GetUser(int userId)
        {
            return _userRepository.Get(userId);
        }

        public List<Role> GetUserRoles(string username)
        {
            List<Role> _result = new List<Role>();

            var existingUser = _userRepository.GetSingleByUsername(username);

            if (existingUser != null)
            {
                foreach (var userRole in existingUser.UserRoles)
                {
                    _result.Add(userRole.Role);
                }
            }

            return _result.Distinct().ToList();
        }
        #endregion

        #region Helper methods
        //private void addUserToRole(User user, int roleId)
        //{
        //    var role = _roleRepository.Get(roleId);
        //    if (role == null)
        //        throw new ApplicationException("Role doesn't exist.");

        //    var userRole = new UserRole()
        //    {
        //        RoleId = role.ID,
        //        UserId = user.ID
        //    };
        //    _userRoleRepository.Add(userRole);
        //}

        private bool isPasswordValid(User user, string password)
        {
            return string.Equals(_encryptionService.EncryptPassword(password, user.Salt), user.Password);
        }

        private bool isUserValid(User user, string password)
        {
            if (isPasswordValid(user, password))
            {
                return !user.IsDeleted;
            }

            return false;
        }

        #endregion
    }
}
