using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateSquares.Data.Persistences
{
    public class DbFactory : IDisposable, IDbFactory
    {
        PrivateSquaresDbContext dbContext;

        public PrivateSquaresDbContext Init()
        {
            return dbContext;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
      
    }
}
