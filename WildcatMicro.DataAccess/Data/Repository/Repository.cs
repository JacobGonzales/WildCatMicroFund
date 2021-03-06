using WildcatMicro.DataAccess.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace WildcatMicro.DataAccess.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;
        internal DbSet<T> dbset;

        public Repository(DbContext context)
        {
            Context = context;
            this.dbset = context.Set<T>();
        }

        public void Add(T entitiy)
        {
            dbset.Add(entitiy);
        }

        public T Get(int id)
        {
            return dbset.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = (filter != null) ? dbset.Where(filter) : dbset;
            
            //included properties will be comma seperated

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[]
                    {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            IEnumerable<T> a = (orderBy != null) ? orderBy(query).ToList() : query.ToList();
            return a;
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = (filter != null) ? dbset.Where(filter) : dbset;

            //included properties will be comma seperated

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[]
                    {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefault();
        }

        public void Remove(int id)
        {
            T entityToRemove = dbset.Find(id);
            Remove(entityToRemove);
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbset.RemoveRange(entity);
        }
    }
}
