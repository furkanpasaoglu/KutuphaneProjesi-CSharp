using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Kutuphane.Business.Abstract;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.Entities.Concrete;

namespace Kutuphane.Business.Concrete
{
    public class BookManager : IBookService
    {
        private IBookDal _bookDal;
        private ICategoryDal _categoryDal;
        private IAuthorDal _authorDal;

        public BookManager(IBookDal bookDal, ICategoryDal categoryDal, IAuthorDal authorService)
        {
            _bookDal = bookDal;
            _categoryDal = categoryDal;
            _authorDal = authorService;
        }
        public List<Book> GetList(Func<Book, bool> filter = null,
            Expression<Func<Book, object>>[] include = null)
        {
            return _bookDal.GetList(filter, include);
        }

        public List<Category> GetCategoryList()
        {
            return _categoryDal.GetList();
        }

        public List<Author> GetAuthorList()
        {
            return _authorDal.GetList();
        }

        public Book GetById(int id)
        {
            return id > 0 ? _bookDal.GetById(p => p.Id == id) : throw new Exception("Hata");
        }

        public void Add(Book book)
        {
            if (book!=null)
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