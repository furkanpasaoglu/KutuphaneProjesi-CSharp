using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Kutuphane.Entities.Concrete;
using X.PagedList;

namespace Kutuphane.Business.Abstract
{
    public interface IPersonalService
    {
        List<Personal> GetList(string p = "");
        Personal GetById(int id);
        void Add(Personal personal);
        void Update(Personal personal);
        void Delete(Personal personal);
    }
}