using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Kutuphane.Entities.Concrete;
using X.PagedList;


namespace Kutuphane.Business.Abstract
{
    public interface IAuthorService
    {
        List<Author> GetList(string p = "");
        Author GetById(int id);
        void Add(Author author);
        void Update(Author author);
        void Delete(Author author);
    }
}