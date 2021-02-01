using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Kutuphane.Business.Abstract;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.Entities.Concrete;

namespace Kutuphane.Business.Concrete
{
    public class AuthorManager : IAuthorService
    {
        private IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal writerDal)
        {
            _authorDal = writerDal;
        }


        public List<Author> GetList(Func<Author, bool> filter = null, params Expression<Func<Author, object>>[] include)
        {
            return _authorDal.GetList(filter, include);
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