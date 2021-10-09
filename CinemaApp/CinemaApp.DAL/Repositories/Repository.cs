using CinemaApp.Common.Models;
using CinemaApp.DAL.Extensions;
using CinemaApp.DAL.Interfaces;
using CinemaApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CinemaApp.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected CinemaAppContext _context;
        public Repository(CinemaAppContext appDbContext)
        {
            _context = appDbContext;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }
        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            var query = IncludeProperties(includeProperties);
            return query;
        }

        public T GetById(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = IncludeProperties(includeProperties).FirstOrDefault(x => x.Id == id);
            return query;
        }

        public PaginatedResult<T> GetPagedData(PagedRequest pagedRequest)
        {
            return _context.Set<T>().CreatePaginatedResult<T>(pagedRequest);
        }

        public PaginatedResult<T> GetPagedDataWithInclude(PagedRequest pagedRequest, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = IncludeProperties(includeProperties);
            return query.CreatePaginatedResult<T>(pagedRequest);
        }

        private IQueryable<T> IncludeProperties(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> entities = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                entities = entities.Include(includeProperty);
            }
            return entities;
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
