using EmployeeManagement.Datas.Contracts;
using EmployeeManagement.Datas.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EmployeeManagement.Datas.Implementation
{
   public class Repository<T> : IRepositoryBase<T> where T : class, new()
    {
        private readonly EMC _ctx;
        internal DbSet<T> dbSet;
            public Repository(EMC ctx)
        {
            this._ctx = ctx;
            this.dbSet = _ctx.Set<T>();
        }
        /// <summary>
        /// Add to T type entity / Genel tipte veriyi kayıt eder.
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query= dbSet;

            if(filter!=null )
                {
                query = query.Where(filter);

            }
            if(includeProperties !=null)
                    {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) 
                {
                    query = query.Include(item);
                }
            }
            if(orderBy!=null)
            {
                return orderBy(query);
            }
            return query;
        }

        public T GetFirstorDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);

            }
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove( entity);
        }

        public void Update(T entity)
        {
            dbSet.Update( entity);
        }
    }
}
