using System;
using System.Collections.Generic;
using System.Linq;
using Kutuphane.Business.Abstract;
using Kutuphane.Business.Constant;
using Kutuphane.Core.Kutuphane.Utilities.Business;
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
            var result = BusinessRules.Run2(CheckByQueryBlank(p));
            if (result!=null)
            {
                return new SuccessDataResult<List<Author>>(_authorDal.GetList().ToList(), Messages.YazarListele);
            }
            return new SuccessDataResult<List<Author>>(_authorDal.GetList().Where(x => x.Name.Contains(p)).ToList(), Messages.YazarListele);
        }

        public IDataResult<Author> GetById(int id)
        {
            var result = BusinessRules.Run2(CheckByIdBlank(id));
            if (result!=null)
                return new ErrorDataResult<Author>(Messages.Hata);

            return new SuccessDataResult<Author>(_authorDal.GetById(p => p.Id == id));

        }

        public IResult Add(Author author)
        {
            var result = BusinessRules.Run(CheckEntityBlank(author));
            if (result != null)
                return new ErrorResult(Messages.Hata);

            _authorDal.Add(author);
            return new SuccessResult(Messages.YazarEkle);
        }

        public IResult Update(Author author)
        {
            var result = BusinessRules.Run(CheckEntityBlank(author));
            if (result != null)
                return new ErrorResult(Messages.Hata);

            _authorDal.Update(author);
            return new SuccessResult(Messages.YazarGüncelle);
        }

        public IResult Delete(Author author)
        {
            var result = BusinessRules.Run(CheckEntityBlank(author));
            if (result != null)
                return new ErrorResult(Messages.Hata);

            _authorDal.Delete(author);
            return new SuccessResult(Messages.YazarSil);
        }

        private IResult CheckEntityBlank(Author author)
        {
            if (author == null)
            {
                return new ErrorResult(Messages.Hata);
            }

            return new SuccessResult();
        }

        private IDataResult<object> CheckByIdBlank(int id)
        {
            if (id > 0)
            {
                return new SuccessDataResult<object>();
            }

            return new ErrorDataResult<object>(Messages.Hata);
        }

        private IDataResult<object> CheckByQueryBlank(string p)
        {
            if (!String.IsNullOrEmpty(p))
            {
                return new SuccessDataResult<object>();
            }

            return new ErrorDataResult<object>();
        }
    }
}