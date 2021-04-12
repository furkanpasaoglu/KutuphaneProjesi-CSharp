using System;
using System.Collections.Generic;
using System.Linq;
using Kutuphane.Business.Abstract;
using Kutuphane.Business.BusinessAspects.Autofac;
using Kutuphane.Business.Constant;
using Kutuphane.Core.Kutuphane.Utilities.Business;
using Kutuphane.Core.Kutuphane.Utilities.Results;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.Entities.Concrete;


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
            var result = BusinessRules.Run2(CheckByQueryBlank(p));
            if (result != null)
                return new SuccessDataResult<List<Category>>(_categoryDal.GetList().ToList(), Messages.KategoriListele);

            return new SuccessDataResult<List<Category>>(_categoryDal.GetList().Where(x => x.Name.Contains(p)).ToList(), Messages.KategoriListele);
        }

        public IDataResult<Category> GetById(int id)
        {
            var result = BusinessRules.Run2(CheckByIdBlank(id));
            if (result != null)
                return new ErrorDataResult<Category>(Messages.Hata);

            return new SuccessDataResult<Category>(_categoryDal.Get(p => p.Id == id));

        }

        public IResult Add(Category category)
        {
            var result = BusinessRules.Run(CheckEntityBlank(category));
            if (result != null)
                return new ErrorResult(Messages.Hata);

            _categoryDal.Add(category);
            return new SuccessResult(Messages.KategoriEkle);
        }

        public IResult Update(Category category)
        {
            var result = BusinessRules.Run(CheckEntityBlank(category));
            if (result != null)
                return new ErrorResult(Messages.Hata);

            _categoryDal.Update(category);
            return new SuccessResult(Messages.KategoriGüncelle);
        }

        public IResult Delete(Category category)
        {
            var result = BusinessRules.Run(CheckEntityBlank(category));
            if (result != null)
                return new ErrorResult(Messages.Hata);

            _categoryDal.Delete(category);
            return new SuccessResult(Messages.KategoriSil);
        }
        private IResult CheckEntityBlank(Category category)
        {
            if (category == null)
            {
                return new ErrorResult(Messages.Hata);
            }

            return new SuccessResult();
        }

        private IDataResult<object> CheckByIdBlank(int id)
        {
            if (id > 0)
            {
                return new SuccessDataResult<object>();
            }

            return new ErrorDataResult<object>(Messages.Hata);
        }

        private IDataResult<object> CheckByQueryBlank(string p)
        {
            if (!String.IsNullOrEmpty(p))
            {
                return new SuccessDataResult<object>();
            }

            return new ErrorDataResult<object>();
        }
    }
}