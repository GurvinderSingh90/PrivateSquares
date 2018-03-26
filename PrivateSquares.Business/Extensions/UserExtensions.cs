using PrivateSquares.Data.EntityModels;
using PrivateSquares.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrivateSquares.Business.Extensions
{
    public static class UserExtensions
    {
        public static User GetSingleByUsername(this IEntityRepository<User> userRepository, string username)
        {
            return userRepository.GetAll().FirstOrDefault(x => x.Email == username);
        }
    }
}
