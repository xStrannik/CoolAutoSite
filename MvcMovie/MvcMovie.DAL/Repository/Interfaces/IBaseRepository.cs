using System;
using System.Linq;
using System.Linq.Expressions;

namespace MvcMovie.DAL.Repository.Interfaces
{
    public interface IBaseRepository
    {
        IQueryable<T> GetAll<T>() where T : class;
        IQueryable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class;
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Edit<T>(T entity) where T : class;
        void Save();
    }
}
