using System;
using System.Linq;
using System.Linq.Expressions;
using ShortLink.Core.Interface;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ShortLink.DataAccessLayer.Context;

namespace ShortLink.Core.Services
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal ShortLinkDbContext Context;
        internal DbSet<TEntity> dbSet;

        public Repository(ShortLinkDbContext _context)
        {
            Context = _context;
            dbSet = Context.Set<TEntity>();
        }

        public virtual TEntity Find(int Id)
        {
            return dbSet.Find(Id);
        }

        public virtual void Delete(int Id)
        {
            TEntity Entry = dbSet.Find(Id);
            Delete(Entry);
        }

        public virtual void Update(int Id)
        {
            TEntity Entry = dbSet.Find(Id);
            Update(Entry);
        }

        public virtual void Insert(TEntity Entry)
        {
            dbSet.Add(Entry);
        }

        public virtual void Update(TEntity Entry)
        {
            dbSet.Attach(Entry);
            Context.Entry(Entry).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity Entry)
        {
            if (Context.Entry(Entry).State == EntityState.Detached)
            {
                dbSet.Attach(Entry);
            }
            dbSet.Remove(Entry);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> Filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy = null, string Properties = "")
        {
            IQueryable<TEntity> Query = dbSet;

            if (Filter != null)
            {
                Query = Query.Where(Filter);
            }

            if (Properties != null)
            {
                foreach (var item in Properties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    Query = Query.Include(item);
                }
            }

            if (OrderBy != null)
            {
                return OrderBy(Query).ToList();
            }
            else
            {
                return Query.ToList();
            }
        }
    }
}
