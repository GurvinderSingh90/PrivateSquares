using PrivateSquares.Business.Repositories.Interfaces;
using PrivateSquares.Data.EntityModels;
using PrivateSquares.Data.Persistences;
using PrivateSquares.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateSquares.Business.Repositories.Implement
{
    public class UserRepository : EntityRepository<User>, IUserRepository
    {
        public UserRepository(PrivateSquaresDbContext context) : base(context)
        {
        }
    }
}
