using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace WildcatMicro.DataAccess.Data.Repository.IRepository
{
    public interface IRepository<T> where T: class 
    {
        //Get Object Id
        T Get(int id);

        //Get all ojects Ienumerable

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null);

        //Get the first or Default
        T GetFirstOrDefault(Expression<Func<T, bool>> filter = null,
            string includeProperties = null);



        //Add
        void Add(T entitiy);

        //Remove by ID
        void Remove(int id);

        //Remove the object itself
        void Remove(T entity);

        //Remove (list a object)
        void RemoveRange(IEnumerable<T> entity);
    }
}
