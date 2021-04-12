using System;
using System.Collections.Generic;
using System.Linq;
using Kutuphane.Business.Abstract;
using Kutuphane.Business.BusinessAspects.Autofac;
using Kutuphane.Business.Constant;
using Kutuphane.Business.ValidationRules.FluentValidation;
using Kutuphane.Core.Kutuphane.Aspects.Autofac.Caching;
using Kutuphane.Core.Kutuphane.Aspects.Autofac.Performance;
using Kutuphane.Core.Kutuphane.Aspects.Autofac.Validation;
using Kutuphane.Core.Kutuphane.CrossCuttingConcerns.Validation;
using Kutuphane.Core.Kutuphane.Utilities.Business;
using Kutuphane.Core.Kutuphane.Utilities.Results;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.Entities.Concrete;
using Kutuphane.Entities.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kutuphane.Business.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public IDataResult<List<BookDetailDto>> GetList(string p)
        {
            var result = BusinessRules.Run2(CheckByQueryBlank(p));
            if (result != null)
                return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBookDetails().ToList(), Messages.KitapListele);

            return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBookDetails().Where(x => x.Name.Contains(p)).ToList(), Messages.KitapListele);
        }

        [CacheAspect]
        public IDataResult<List<SelectListItem>> GetCategory()
        {
            return new SuccessDataResult<List<SelectListItem>>(_bookDal.GetCategory());
        }
        [CacheAspect]
        public IDataResult<List<SelectListItem>> GetAuthor()
        {
            return new SuccessDataResult<List<SelectListItem>>(_bookDal.GetAuthor());
        }

        public IDataResult<Book> GetById(int id)
        {
            var result = BusinessRules.Run2(CheckByIdBlank(id));
            if (result != null)
                return new ErrorDataResult<Book>(Messages.Hata);

            return new SuccessDataResult<Book>(_bookDal.Get(p => p.Id == id));
            
        }

        [ValidationAspect(typeof(BookValidator))]
        public IResult Add(Book book)
        {
            var result = BusinessRules.Run(CheckEntityBlank(book));
            if (result != null)
                return new ErrorResult(Messages.Hata);

            _bookDal.Add(book);
            return new SuccessResult(Messages.KitapEkle);
        }

        [ValidationAspect(typeof(BookValidator))]
        public IResult Update(Book book)
        {
            var result = BusinessRules.Run(CheckEntityBlank(book));
            if (result != null)
                return new ErrorResult(Messages.Hata);

            _bookDal.Update(book);
            return new SuccessResult(Messages.KitapGüncelle);
        }

        [ValidationAspect(typeof(BookValidator))]
        [CacheRemoveAspect("IBookService.Get")]
        public IResult Delete(Book book)
        {
            var result = BusinessRules.Run(CheckEntityBlank(book));
            if (result != null)
                return new ErrorResult(Messages.Hata);

            _bookDal.Delete(book);
            return new SuccessResult(Messages.KitapSil);
        }
        private IDataResult<object> CheckByQueryBlank(string p)
        {
            if (!String.IsNullOrEmpty(p))
            {
                return new SuccessDataResult<object>();
            }

            return new ErrorDataResult<object>();
        }
        private IResult CheckEntityBlank(Book book)
        {
            if (book == null)
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
    }
}