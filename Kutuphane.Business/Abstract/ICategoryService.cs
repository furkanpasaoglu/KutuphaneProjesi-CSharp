using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Kutuphane.Entities.Concrete;

namespace Kutuphane.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList(Func<Category, bool> filter = null, params Expression<Func<Category, object>>[] include);
        Category GetById(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}