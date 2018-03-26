using PrivateSquares.Business.DomainModels;
using PrivateSquares.Data.EntityModels;
using PrivateSquares.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateSquares.Services
{
    public interface IMembershipService
    {
        MembershipContext ValidateUser(string username, string password);
        User CreateUser(UserView userView);
        User GetUser(int userId);
        List<Role> GetUserRoles(string username);
    }
}
