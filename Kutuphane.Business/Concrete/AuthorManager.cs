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

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public List<Author> GetList(string p = "")
        {
            if (!String.IsNullOrEmpty(p))
            {
                return _authorDal.GetList().Where(x => x.Name.Contains(p)).ToList();
            }
            else
            {
                return _authorDal.GetList().ToList();
            }
        }

        public Author GetById(int id)
        {
            return id > 0 ? _authorDal.GetById(p => p.Id == id) : throw new Exception("Hata");
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