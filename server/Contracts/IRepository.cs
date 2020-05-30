using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Contracts
{
    public interface IRepository
    {
        int SaveChanges();

        T Get<T>(params object[] id) where T : class;

        T Get<T>(Expression<Func<T, bool>> selector, Expression<Func<T, dynamic>>[] includingNavigationPaths = null) where T : class;

        T First<T>(Expression<Func<T, bool>> predicate = null,
                                  Expression<Func<T, dynamic>>[] includingNavigationPaths = null) where T : class;
        IQueryable<T> GetAll<T>() where T : class;


        void Insert<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        
    }
}
