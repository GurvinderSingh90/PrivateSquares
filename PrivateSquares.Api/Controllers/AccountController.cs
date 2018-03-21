using Microsoft.AspNetCore.Mvc;
using PrivateSquares.Business.Repositories.Interfaces;
using PrivateSquares.Data.EntityModels;
using System;

namespace PrivateSquares.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public string Get()
        {
            return "1";
        }

        [HttpPost]
        public int Register(User user)
        {
            user.UserID = Guid.NewGuid();
            user.ApprovedBy = user.UserID;
            user.CreatedOn = DateTime.Now;
            user.EmailVerification = Guid.NewGuid();
            user.IsActived = false;
            user.IsDeleted = false;
            user.ModifyOn = DateTime.Now;
            user.RoleID = 0;
            _userRepository.Add(user);
            return 1;
        }
    }
}