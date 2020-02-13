using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ToolRental.DataAccess.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        // Get Object By ID 
        T Get(int id);

        // Get All objects 
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            string includeProperties = null);

        // Get First or Default Object
        T GetFirstORDefault(Expression<Func<T, bool>> filter = null,
            string includeProperties = null);
        // Add 
        void Add(T entity);

        // Remove( id)
        void Remove(int id);
        // Remove(Object)
        void Remove(T entity);
    }
}
