using PrivateSquares.Data.EntityModels;
using PrivateSquares.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateSquares.Business.Repositories.Interfaces
{
    public interface IUserRepository: IEntityRepository<User>
    {
        bool IsEmailExist(string sEmail);
        bool ValidateUser(string Username, string Password);

    }
}
