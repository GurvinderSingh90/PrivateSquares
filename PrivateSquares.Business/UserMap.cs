using AutoMapper;
using PrivateSquares.Business.Abstract;
using PrivateSquares.Business.DomainModels;
using PrivateSquares.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateSquares.Business
{
    public class UserMap : IUserMap
    {
        public User AddUserMapping(UserView oUserView)
        {
            oUserView.UserID = Guid.NewGuid();
            oUserView.ApprovedBy = oUserView.UserID;
            oUserView.CreatedOn = DateTime.Now;
            //oUserView.EmailVerification = Guid.NewGuid();
            oUserView.IsActive = false;
            oUserView.IsDeleted = false;
            oUserView.ModifyOn = DateTime.Now;
            oUserView.RoleID = 0;
            return Mapper.Map<UserView, User>(oUserView);
        }
    }
}
