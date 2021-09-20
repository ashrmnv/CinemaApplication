using CinemaApp.Domain;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CinemaApp.DAL.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        T GetById(int id);
        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
