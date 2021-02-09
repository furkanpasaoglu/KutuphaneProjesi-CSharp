using System;
using System.Collections.Generic;
using System.Linq;
using Kutuphane.Business.Abstract;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.Entities.Concrete;
using Kutuphane.Entities.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kutuphane.Business.Concrete
{
    public class BookManager : IBookService
    {
        private IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public List<BookDetailDto> GetList(string p)
        {
            if (!String.IsNullOrEmpty(p))
            {
                return _bookDal.GetBookDetails().Where(x => x.Name.Contains(p)).ToList();
            }
            else
            {
                return _bookDal.GetBookDetails().ToList();
            }
        }

        public List<SelectListItem> GetCategory()
        {
            return _bookDal.GetCategory();
        }

        public List<SelectListItem> GetAuthor()
        {
            return _bookDal.GetAuthor();
        }

        public Book GetById(int id)
        {
            return id > 0 ? _bookDal.GetById(p => p.Id == id) : throw new Exception("Hata");
        }

        public void Add(Book book)
        {
            if (book != null)
            {
                _bookDal.Add(book);
            }
            else
            {
                throw new Exception("Hata");
            }
        }

        public void Update(Book book)
        {
            if (book != null)
            {
                _bookDal.Update(book);
            }
            else
            {
                throw new Exception("Hata");
            }
        }

        public void Delete(Book book)
        {
            if (book != null)
            {
                _bookDal.Delete(book);
            }
            else
            {
                throw new Exception("Hata");
            }
        }
    }
}