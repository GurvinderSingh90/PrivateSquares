using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PrivateSquares.Api.Infrastructure.Core;
using PrivateSquares.Business;
using PrivateSquares.Business.DomainModels;
using PrivateSquares.Data.EntityModels;
using PrivateSquares.Data.Persistences;
using PrivateSquares.Data.Repositories;
using PrivateSquares.Services;
using PrivateSquares.Services.Utilities;
using System;
using System.Net;
using System.Net.Http;
using static Microsoft.AspNetCore.WebSockets.Internal.Constants;

namespace PrivateSquares.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : ApiControllerBase
    {
        private readonly IMembershipService _membershipService;
        //private readonly IUserMap _userMap;
        //UserMap objUserMap = new UserMap();
        public AccountController(IMembershipService membershipService, 
            IEntityRepository<Error> _errorRepository, IUnitOfWork _unitOfWork):base(_errorRepository, _unitOfWork)
        {
            _membershipService = membershipService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginView user)
        {
            //if (ModelState.IsValid)
            //{
            //    MembershipContext _userContext = _membershipService.ValidateUser(user.UserName, user.Password);
            //    if (_userContext.User != null)
            //    {
            //        Request.HttpContext.Response.Headers.Add("UserName", _userContext.Principal.Identity.Name);
            //        return new ContentResult { Content = "Successed!", StatusCode = (int)HttpStatusCode.OK, ContentType = "txt/html" };
            //    }
            //    else
            //        return new ContentResult { Content = "Failed", StatusCode = (int)HttpStatusCode.OK, ContentType = "txt/html" };
            //}
            //else
            //    return new ContentResult { StatusCode = (int)HttpStatusCode.BadRequest };


            var token = new JwtTokenBuilder()
                            .AddSecurityKey(JwtSecurityKey.Create("fiver-secret-key"))
                            .AddSubject("james bond")
                            .AddIssuer("Fiver.Security.Bearer")
                            .AddAudience("Fiver.Security.Bearer")
                            .AddClaim("MembershipId", "111")
                            .AddExpiry(1)
                            .Build();

            return new JsonResult(token);
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public IActionResult Register([FromBody]UserView oUserView)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new ContentResult { StatusCode = (int)HttpStatusCode.BadRequest };
                else
                {
                    User _user = _membershipService.CreateUser(oUserView);
                    if (_user != null)
                        return new ContentResult { Content = Constaints.USER_ADDED_SUC, StatusCode = (int)HttpStatusCode.OK, ContentType = "text/plain" };
                    else
                        return new ContentResult { StatusCode = 404, ContentType = "text/plain" };
                }
            }
            catch(Exception ex)
            {
                return new ContentResult { Content = ex.Message, ContentType = "text/plain" };
            }
        }
    }
}