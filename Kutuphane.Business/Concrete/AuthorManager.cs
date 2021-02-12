using System;
using System.Collections.Generic;
using System.Linq;
using Kutuphane.Business.Abstract;
using Kutuphane.Business.Constant;
using Kutuphane.Core.Kutuphane.Utilities.Results;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.Entities.Concrete;

namespace Kutuphane.Business.Concrete
{
    public class AuthorManager : IAuthorService
    {
        private readonly IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public IDataResult<List<Author>> GetList(string p = "")
        {
            if (!String.IsNullOrEmpty(p))
            {
                return new SuccessDataResult<List<Author>>(_authorDal.GetList().Where(x => x.Name.Contains(p)).ToList(), Messages.YazarListele);
            }
            return new SuccessDataResult<List<Author>>(_authorDal.GetList().ToList(),Messages.YazarListele);
        }

        public IDataResult<Author> GetById(int id)
        {
            if (id > 0)
            {
                return new SuccessDataResult<Author>(_authorDal.GetById(p => p.Id == id));
            }
            return new ErrorDataResult<Author>(Messages.Hata);
        }

        public IResult Add(Author author)
        {
            if (author != null)
            {
                _authorDal.Add(author);
                return new SuccessResult(Messages.YazarEkle);
            }
            return new ErrorResult(Messages.Hata);
        }

        public IResult Update(Author author)
        {
            if (author != null)
            {
                _authorDal.Update(author);
                return new SuccessResult(Messages.YazarGüncelle);
            }
            return new ErrorResult(Messages.Hata);
        }

        public IResult Delete(Author author)
        {
            if (author != null)
            {
                _authorDal.Delete(author);
                return new SuccessResult(Messages.YazarSil);
            }
            return new ErrorResult(Messages.Hata);
        }
    }
}