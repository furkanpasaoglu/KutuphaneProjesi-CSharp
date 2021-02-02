using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Kutuphane.Entities.Concrete;
using X.PagedList;

namespace Kutuphane.Business.Abstract
{
    public interface IPersonalService
    {
        IPagedList<Personal> GetList(int page, int pageSize, Func<Personal, bool> filter = null,
            params Expression<Func<Personal, object>>[] include);
        Personal GetById(int id);
        void Add(Personal personal);
        void Update(Personal personal);
        void Delete(Personal personal);
    }
}