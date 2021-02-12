using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Kutuphane.Business.Abstract;
using Kutuphane.Business.Constant;
using Kutuphane.Core.Kutuphane.Utilities.Results;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.Entities.Concrete;
using X.PagedList;


namespace Kutuphane.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }


        public IDataResult<List<Category>> GetList(string p = "")
        {
            if (!String.IsNullOrEmpty(p))
            {
                return new SuccessDataResult<List<Category>>(_categoryDal.GetList().Where(x => x.Name.Contains(p)).ToList(), Messages.KategoriListele);
            }
            return new SuccessDataResult<List<Category>>(_categoryDal.GetList().ToList(), Messages.KategoriListele);
        }

        public IDataResult<Category> GetById(int id)
        {
            if (id > 0)
            {
                return new SuccessDataResult<Category>(_categoryDal.GetById(p => p.Id == id));
            }

            return new ErrorDataResult<Category>(Messages.Hata);
        }

        public IResult Add(Category category)
        {
            if (category != null)
            {
                _categoryDal.Add(category);
                return new SuccessResult(Messages.KategoriEkle);
            }

            return new ErrorResult(Messages.Hata);
        }

        public IResult Update(Category category)
        {
            if (category != null)
            {
                _categoryDal.Update(category);
                return new SuccessResult(Messages.KategoriGüncelle);
            }
            return new ErrorResult(Messages.Hata);
        }

        public IResult Delete(Category category)
        {
            if (category != null)
            {
                _categoryDal.Delete(category);
                return new SuccessResult(Messages.KategoriSil);
            }
            return new ErrorResult(Messages.Hata);
        }
    }
}