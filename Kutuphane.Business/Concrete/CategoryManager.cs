using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Kutuphane.Business.Abstract;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.Entities.Concrete;


namespace Kutuphane.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetList(Func<Category, bool> filter = null,
            Expression<Func<Category, object>>[] include = null)
        {
            return _categoryDal.GetList(filter, include);
        }

        public Category GetById(int id)
        {
            return id > 0 ? _categoryDal.GetById(p => p.Id == id) : throw new Exception("Hata");
        }

        //public List<Category> GetListByCategory(int id)
        //{
        //    return id > 0 ? _categoryDal.GetList(p => p.Id == id).ToList() : throw new Exception("Hata");
        //}

        public void Add(Category category)
        {
            if (category != null)
            {
                _categoryDal.Add(category);
            }
            else
            {
                throw new Exception("Hata");
            }
        }

        public void Update(Category category)
        {
            if (category != null)
            {
                _categoryDal.Update(category);
            }
            else
            {
                throw new Exception("Hata");
            }
        }

        public void Delete(Category category)
        {
            if (category != null)
            {
                _categoryDal.Delete(category);
            }
            else
            {
                throw new Exception("Hata");
            }
        }
    }
}