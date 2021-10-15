using CinemaApp.Common.Models;
using CinemaApp.Domain;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CinemaApp.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity GetById(int id, params Expression<Func<TEntity, object>>[] includeProperties);
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        PaginatedResult<TEntity> GetPagedData(PagedRequest pagedRequest);
        PaginatedResult<TEntity> GetPagedDataWithInclude(PagedRequest pagedRequest, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
