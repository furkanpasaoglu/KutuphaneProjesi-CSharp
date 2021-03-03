using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Kutuphane.Core.Kutuphane.Entities;

namespace Kutuphane.Core.Kutuphane.DataAccess
{
    public interface IEntityRepository<T>
    where T:class,IEntity,new()
    {
        /*
        List<T> GetList(Func<T, bool> filter = null, params Expression<Func<T, object>>[]include);
        List<T> GetList(params Expression<Func<T, object>>[] include);
        List<T> GetList(Func<T, bool> filter);
        */
        List<T> GetList();
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}