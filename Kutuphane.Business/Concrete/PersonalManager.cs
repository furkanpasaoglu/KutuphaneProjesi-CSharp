using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Kutuphane.Business.Abstract;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.Entities.Concrete;
using X.PagedList;

namespace Kutuphane.Business.Concrete
{
    public class PersonalManager : IPersonalService
    {
        private IPersonalDal _personelDal;

        public PersonalManager(IPersonalDal personelDal)
        {
            _personelDal = personelDal;
        }

        public IPagedList<Personal> GetList(int page, int pageSize, Func<Personal, bool> filter = null, params Expression<Func<Personal, object>>[] include)
        {
            if (page > 0 && pageSize > 0)
            {
                return _personelDal.GetList(filter, include).ToPagedList(page, pageSize);
            }
            else
            {
                return _personelDal.GetList(filter, include).ToPagedList(page, pageSize);
            }
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