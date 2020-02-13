using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ToolRental.DataAccess.Data.Repository.IRepository;

namespace ToolRental.DataAccess.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        internal DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            Context = context;
            this.dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            
                dbSet.Add(entity);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet; 
            
            if(filter != null)
            {
                query = query.Where(filter);
            }
            // Will be comma sperated 
            if (includeProperties != null)
            {
                foreach(var includeProrerty in includeProperties.Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProrerty);
                }
            }

            if(orderby != null)
            {
                return orderby(query).ToList();
            }
            return query.ToList();
        }

        public T GetFirstORDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            // Will be comma sperated 
            if (includeProperties != null)
            {
                foreach (var includeProrerty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProrerty);
                }
            }

            return query.FirstOrDefault();
        }

        public void Remove(int id)
        {
            Remove(dbSet.Find(id));
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
