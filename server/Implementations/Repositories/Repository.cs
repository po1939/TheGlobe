using Contracts;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Implementations.Repositories
{
    public class Repository : IRepository
    {
        protected DatabaseContext _dbContext { get; set; }

        public Repository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual int SaveChanges()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public T Get<T>(params object[] id) where T : class
        {
            return _dbContext.Set<T>().Find(id);
        }

        public T Get<T>(Expression<Func<T, bool>> selector, Expression<Func<T, dynamic>>[] includingNavigationPaths = null)
            where T : class
        {
            return First(selector, includingNavigationPaths);
        }

        public virtual T First<T>(Expression<Func<T, bool>> predicate = null,
                                  Expression<Func<T, dynamic>>[] includingNavigationPaths = null) where T : class
        {
            var dbSet = _dbContext.Set<T>() as IQueryable<T>;

            if (includingNavigationPaths != null && includingNavigationPaths.Any())
            {
                dbSet = includingNavigationPaths.Aggregate(
                    dbSet, (dbSetInstance, navigationPath) => dbSetInstance.Include(navigationPath));
            }

            return predicate == null
                       ? dbSet.FirstOrDefault()
                       : dbSet.FirstOrDefault(predicate);
        }

        public virtual IQueryable<T> GetAll<T>() where T : class
        {
            var dbSet = _dbContext.Set<T>();
            return dbSet.AsQueryable();
        }

        public virtual void Insert<T>(T entity) where T : class
        {
            var entityEntry = _dbContext.Entry(entity);

            if (entityEntry.State != EntityState.Detached)
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                _dbContext.Set<T>().Add(entity);
            }
        }

        public virtual void Update<T>(T entity) where T : class
        {
            var entityEntry = _dbContext.Entry(entity);

            if (entityEntry.State == EntityState.Detached)
            {
                _dbContext.Set<T>().Attach(entity);
            }


            entityEntry.State = EntityState.Modified;
        }

        public virtual void Delete<T>(T entity) where T : class
        {
            try
            {
                ((dynamic)entity).IsDeleted = true;
                Update(entity);
            }
            catch
            {
                _dbContext.Set<T>().Remove(entity);
            }
        }


    }
}
