using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Kutuphane.Business.Abstract;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.Entities.Concrete;

namespace Kutuphane.Business.Concrete
{
    public class PersonalManager : IPersonalService
    {
        private IPersonalDal _personelDal;

        public PersonalManager(IPersonalDal personelDal)
        {
            _personelDal = personelDal;
        }


        public List<Personal> GetList(Func<Personal, bool> filter = null, params Expression<Func<Personal, object>>[] include)
        {
            return _personelDal.GetList(filter, include);

        }

        public Personal GetById(int id)
        {
            return id > 0 ? _personelDal.GetById(p => p.Id == id) : throw new Exception("Hata");
        }

        public void Add(Personal personal)
        {
            if (personal != null)
            {
                _personelDal.Add(personal);
            }
            else
            {
                throw new Exception("Hata");
            }
        }

        public void Update(Personal personal)
        {
            if (personal != null)
            {
                _personelDal.Update(personal);
            }
            else
            {
                throw new Exception("Hata");
            }
        }

        public void Delete(Personal personal)
        {
            if (personal != null)
            {
                _personelDal.Delete(personal);
            }
            else
            {
                throw new Exception("Hata");
            }
        }
    }
}