using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Kutuphane.Entities.Concrete;


namespace Kutuphane.Business.Abstract
{
    public interface IAuthorService
    {
        List<Author> GetList(Func<Author, bool> filter = null, params Expression<Func<Author, object>>[] include);
        Author GetById(int id);
        void Add(Author author);
        void Update(Author author);
        void Delete(Author author);
    }
}