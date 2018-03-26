using PrivateSquares.Business.Repositories.Interfaces;
using PrivateSquares.Data.EntityModels;
using PrivateSquares.Data.Persistences;
using PrivateSquares.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrivateSquares.Business.Repositories.Implement
{
    public class UserRepository : EntityRepository<User>, IUserRepository
    {
        PrivateSquaresDbContext context;
        public UserRepository(PrivateSquaresDbContext context) : base(context)
        {
            this.context = context;
        }

        public bool IsEmailExist(string sEmail)
        {
            return context.Users.Any(x => x.Email.Contains(sEmail.Trim()));
        }

        public bool ValidateUser(string Username, string Password)
        {
            //int Id = 0;
            //Id = context.Users
            //    .Where(x => x.Email.ToLower() == Username.Trim().ToLower() && x.Password == Password)
            //    .Select(x => x.ID)
            //    .FirstOrDefault();
            //if (Id > 0)
            //    return 1;
            ////UserID = context.Users.Where(x => x.ID == Id).Select(x => x.UserID).FirstOrDefault();
            //else
            //    return 0;

            return context.Users.Any(x => x.Email.ToLower() == Username.Trim().ToLower() && x.Password == Password);
        }
    }
}
