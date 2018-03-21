using System;
using System.Collections.Generic;
using System.Text;

namespace PrivateSquares.Data.Persistences
{
    public class UnitOfWork : IUnitOfWork
    {
        //private readonly IDbFactory dbFactory;
        private PrivateSquaresDbContext dbContext;

        public UnitOfWork(PrivateSquaresDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public PrivateSquaresDbContext DbContext
        //{
        //    get { return dbContext ?? (dbContext = dbFactory.Init()); }
        //}

        public void Commit()
        {
            dbContext.Commit();
        }
    }
}
