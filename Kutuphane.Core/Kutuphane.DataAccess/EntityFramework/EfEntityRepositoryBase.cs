using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Kutuphane.Core.Kutuphane.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.Core.Kutuphane.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public List<TEntity> GetList()
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }
        /*
        List<TEntity> _query = new List<TEntity>();
        public List<TEntity> GetList(params Expression<Func<TEntity, object>>[] include)
        {
            using (TContext context = new TContext())
            {
                foreach (var x in include)
                {
                    _query = context.Set<TEntity>().Include(x).ToList();
                }
                return _query;
            }
        }


        public List<TEntity> GetList(Func<TEntity, bool> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).ToList();
            }
        }
        public List<TEntity> GetList(Func<TEntity, bool> filter = null, params Expression<Func<TEntity, object>>[] include)
        {
            using (TContext context = new TContext())
            {
                if (include.Any())
                {
                    if (filter == null)
                    {
                        foreach (var x in include)
                        {
                            _query = context.Set<TEntity>().Include(x).ToList();
                        }
                        return _query;
                    }
                    else
                    {
                        foreach (var x in include)
                        {
                            _query = context.Set<TEntity>().Include(x).ToList();
                        }
                        return _query.Where(filter).ToList();
                    }
                }

                return filter != null ? context.Set<TEntity>().Where(filter).ToList() : context.Set<TEntity>().ToList();
            }
        }
        */
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}