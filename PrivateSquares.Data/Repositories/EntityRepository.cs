using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PrivateSquares.Data.EntityModels;
using PrivateSquares.Data.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PrivateSquares.Data.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class, IEntityBase, new()
    {
        private PrivateSquaresDbContext context;

        public EntityRepository(PrivateSquaresDbContext context)
        {
            this.context = context;
        }

        public virtual IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public virtual IQueryable<T> All
        {
            get
            {
                return GetAll();
            }
        }

        public T Get(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public void Add(T entity)
        {
            EntityEntry dbEntityEntry = context.Entry<T>(entity);
            context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            EntityEntry dbEntityEntry = context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public void Edit(T entity)
        {
            EntityEntry dbEntityEntry = context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }
    }
}
