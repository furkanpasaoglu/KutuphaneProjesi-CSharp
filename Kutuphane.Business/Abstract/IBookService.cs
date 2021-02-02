using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Kutuphane.Entities.Concrete;
using X.PagedList;

namespace Kutuphane.Business.Abstract
{
    public interface IBookService
    {
        IPagedList<Book> GetList(int page, int pageSize, Func<Book, bool> filter = null,
            params Expression<Func<Book, object>>[] include);
        //List<Book> GetList(Func<Book, bool> filter = null, params Expression<Func<Book, object>>[] include);
        List<Category> GetCategoryList();
        List<Author> GetAuthorList();
        Book GetById(int id);
        void Add(Book book);
        void Update(Book book);
        void Delete(Book book);
    }
}