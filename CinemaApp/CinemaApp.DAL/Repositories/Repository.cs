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
        protected CinemaAppContext context;
        public Repository(CinemaAppContext appDbContext)
        {
            context = appDbContext;
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }
        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }
        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public PaginatedResult<T> GetPagedData(PagedRequest pagedRequest)
        {
            return context.Set<T>().CreatePaginatedResult<T>(pagedRequest);
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
