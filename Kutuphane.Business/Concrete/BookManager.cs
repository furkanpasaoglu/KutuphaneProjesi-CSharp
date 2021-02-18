using System;
using System.Collections.Generic;
using System.Linq;
using Kutuphane.Business.Abstract;
using Kutuphane.Business.Constant;
using Kutuphane.Business.ValidationRules.FluentValidation;
using Kutuphane.Core.Kutuphane.CrossCuttingConcerns.Validation;
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
            if (!String.IsNullOrEmpty(p))
            {
                return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBookDetails().Where(x => x.Name.Contains(p)).ToList(),Messages.KitapListele);
            }
            return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBookDetails().ToList(),Messages.KitapListele);
        }

        public IDataResult<List<SelectListItem>> GetCategory()
        {
            return new SuccessDataResult<List<SelectListItem>>(_bookDal.GetCategory());
        }

        public IDataResult<List<SelectListItem>> GetAuthor()
        {
            return new SuccessDataResult<List<SelectListItem>>(_bookDal.GetAuthor());
        }

        public IDataResult<Book> GetById(int id)
        {
            if (id > 0)
            {
                return new SuccessDataResult<Book>(_bookDal.GetById(p => p.Id == id));
            }
            return new ErrorDataResult<Book>(Messages.Hata);
        }

        public IResult Add(Book book)
        {
            ValidationTool.Validate(new BookValidator(),book);
            _bookDal.Add(book);
            return new SuccessResult(Messages.KitapEkle);
        }

        public IResult Update(Book book)
        {
            ValidationTool.Validate(new BookValidator(), book);
            _bookDal.Update(book);
            return new SuccessResult(Messages.KitapGüncelle);
        }

        public IResult Delete(Book book)
        {
            ValidationTool.Validate(new BookValidator(), book);
            _bookDal.Delete(book);
            return new SuccessResult(Messages.KitapSil);
        }
    }
}