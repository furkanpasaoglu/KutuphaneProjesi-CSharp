using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Kutuphane.Business.Abstract;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.Entities.Concrete;
using X.PagedList;


namespace Kutuphane.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }


        public List<Category> GetList(string p = "")
        {
            if (!String.IsNullOrEmpty(p))
            {
                return _categoryDal.GetList().Where(x => x.Name.Contains(p)).ToList();
            }
            else
            {
                return _categoryDal.GetList().ToList();
            }
        }

        public Category GetById(int id)
        {
            return id > 0 ? _categoryDal.GetById(p => p.Id == id) : throw new Exception("Hata");
        }

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