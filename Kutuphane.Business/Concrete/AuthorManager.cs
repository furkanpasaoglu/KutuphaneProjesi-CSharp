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
    public class AuthorManager : IAuthorService
    {
        private IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal writerDal)
        {
            _authorDal = writerDal;
        }

        public IPagedList<Author> GetList(int page = 0, int pageSize = 0, Func<Author, bool> filter = null,
            params Expression<Func<Author, object>>[] include)
        {
            if (page > 0 && pageSize > 0)
            {
                return _authorDal.GetList(filter, include).ToPagedList(page,pageSize);
            }
            else
            {
                return _authorDal.GetList(filter, include).ToPagedList(page,pageSize);
            }

        }

        public Author GetById(int id)
        {
            return id > 0 ? _authorDal.GetById(p => p.Id == id):throw new Exception("Hata");
        }

        public void Add(Author author)
        {
            if (author != null)
            {
                _authorDal.Add(author);
            }
            else
            {
                throw new Exception("Hata");
            }
        }

        public void Update(Author author)
        {
            if (author != null)
            {
                _authorDal.Update(author);
            }
            else
            {
                throw new Exception("Hata");
            }

        }

        public void Delete(Author author)
        {
            if (author != null)
            {
                _authorDal.Delete(author);
            }
            else
            {
                throw new Exception("Hata");
            }
        }
    }
}