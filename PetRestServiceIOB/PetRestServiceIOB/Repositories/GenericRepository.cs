using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Ajax.Utilities;
using PetRestServiceIOB.Models;

namespace PetRestServiceIOB.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal PetRestServiceIOBContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(PetRestServiceIOBContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
        {
            return dbSet.SqlQuery(query, parameters).ToList();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter));
            if (filter == null) throw new ArgumentNullException(nameof(filter));
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }


        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }


        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = dbSet;
            return query.ToList();
        }

        
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

       
        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        
        public virtual IEnumerable<TEntity> GetMany(Func<TEntity, bool> where)
        {
            return dbSet.Where(where).ToList();
        }

       
        public virtual IQueryable<TEntity> GetManyQueryable(Func<TEntity, bool> where)
        {
            return dbSet.Where(where).AsQueryable();
        }

        
        public TEntity Get(Func<TEntity, Boolean> where)
        {
            return dbSet.Where(where).FirstOrDefault<TEntity>();
        }

  
        public void Delete(Func<TEntity, Boolean> where)
        {
            IQueryable<TEntity> objects = dbSet.Where<TEntity>(where).AsQueryable();
            foreach (TEntity obj in objects)
                dbSet.Remove(obj);
        }

     
        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        
        public IQueryable<TEntity> GetWithInclude(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, params string[] include)
        {
            IQueryable<TEntity> query = this.dbSet;
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(predicate);
        }

        public bool Exists(object primaryKey)
        {
            return dbSet.Find(primaryKey) != null;
        }

        
        public TEntity GetSingle(Func<TEntity, bool> predicate)
        {
            return dbSet.Single<TEntity>(predicate);
        }

        
        public TEntity GetFirst(Func<TEntity, bool> predicate)
        {
            return dbSet.First<TEntity>(predicate);
        }


       
    }
}
