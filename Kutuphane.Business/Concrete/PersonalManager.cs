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
    public class PersonalManager : IPersonalService
    {
        private readonly IPersonalDal _personelDal;

        public PersonalManager(IPersonalDal personelDal)
        {
            _personelDal = personelDal;
        }


        public IDataResult<List<Personal>> GetList(string p = "")
        {
            if (!String.IsNullOrEmpty(p))
            {
                return new SuccessDataResult<List<Personal>>(_personelDal.GetList().Where(x => x.Name.Contains(p)).ToList(), Messages.PersonelListele);
            }
            return new SuccessDataResult<List<Personal>>(_personelDal.GetList().ToList(), Messages.PersonelListele);
        }

        public IDataResult<Personal> GetById(int id)
        {
            if (id>0)
            {
                return new SuccessDataResult<Personal>(_personelDal.GetById(p => p.Id == id));
            }

            return new ErrorDataResult<Personal>(Messages.Hata);
        }

        public IResult Add(Personal personal)
        {
            if (personal != null)
            {
                _personelDal.Add(personal);
                return new SuccessResult(Messages.PersonelEkle);
            }
            return new ErrorResult(Messages.Hata);
        }

        public IResult Update(Personal personal)
        {
            if (personal != null)
            {
                _personelDal.Update(personal);
                return new SuccessResult(Messages.PersonelGüncelle);
            }
            return new ErrorResult(Messages.Hata);
        }

        public IResult Delete(Personal personal)
        {
            if (personal != null)
            {
                _personelDal.Delete(personal);
                return new SuccessResult(Messages.PersonelSil);
            }
            return new ErrorResult(Messages.Hata);
        }
    }
}