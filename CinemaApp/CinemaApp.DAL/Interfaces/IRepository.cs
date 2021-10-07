using CinemaApp.Common.Models;
using CinemaApp.Domain;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CinemaApp.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity GetById(int id);
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        PaginatedResult<TEntity> GetPagedData(PagedRequest pagedRequest);
    }
}
