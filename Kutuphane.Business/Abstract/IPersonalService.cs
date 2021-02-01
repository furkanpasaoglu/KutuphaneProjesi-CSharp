using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Kutuphane.Entities.Concrete;

namespace Kutuphane.Business.Abstract
{
    public interface IPersonalService
    {
        List<Personal> GetList(Func<Personal, bool> filter = null, params Expression<Func<Personal, object>>[] include);
        Personal GetById(int id);
        void Add(Personal personal);
        void Update(Personal personal);
        void Delete(Personal personal);
    }
}