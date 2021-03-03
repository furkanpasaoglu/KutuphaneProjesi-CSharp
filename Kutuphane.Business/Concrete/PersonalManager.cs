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
    public class PersonalManager : IPersonalService
    {
        private readonly IPersonalDal _personelDal;

        public PersonalManager(IPersonalDal personelDal)
        {
            _personelDal = personelDal;
        }

        public IDataResult<List<Personal>> GetList(string p = "")
        {
            var result = BusinessRules.Run2(CheckByQueryBlank(p));
            if (result != null)
                return new SuccessDataResult<List<Personal>>(_personelDal.GetList().ToList(), Messages.PersonelListele);

            return new SuccessDataResult<List<Personal>>(_personelDal.GetList().Where(x => x.Name.Contains(p)).ToList(), Messages.PersonelListele);
        }

        public IDataResult<Personal> GetById(int id)
        {
            var result = BusinessRules.Run2(CheckByIdBlank(id));
            if (result != null)
                return new ErrorDataResult<Personal>(Messages.Hata);

            return new SuccessDataResult<Personal>(_personelDal.Get(p => p.Id == id));
        }

        public IResult Add(Personal personal)
        {
            var result = BusinessRules.Run(CheckEntityBlank(personal));
            if (result != null)
                return new ErrorResult(Messages.Hata);

            _personelDal.Add(personal);
            return new SuccessResult(Messages.PersonelEkle);
        }

        public IResult Update(Personal personal)
        {
            var result = BusinessRules.Run(CheckEntityBlank(personal));
            if (result != null)
                return new ErrorResult(Messages.Hata);

            _personelDal.Update(personal);
            return new SuccessResult(Messages.PersonelGüncelle);
        }

        public IResult Delete(Personal personal)
        {
            var result = BusinessRules.Run(CheckEntityBlank(personal));
            if (result != null)
                return new ErrorResult(Messages.Hata);

            _personelDal.Delete(personal);
            return new SuccessResult(Messages.PersonelSil);
        }

        private IResult CheckEntityBlank(Personal personal)
        {
            if (personal == null)
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