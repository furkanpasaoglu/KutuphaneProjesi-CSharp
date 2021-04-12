using System.Collections.Generic;
using Kutuphane.Business.Abstract;
using Kutuphane.Business.BusinessAspects.Autofac;
using Kutuphane.Business.Constant;
using Kutuphane.Core.Kutuphane.Utilities.Business;
using Kutuphane.Core.Kutuphane.Utilities.Results;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.Entities.Concrete;

namespace Kutuphane.Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public IResult Add(Contact contact)
        {
            var result = BusinessRules.Run(CheckEntityBlank(contact));
            if (result != null)
                return new ErrorResult(Messages.Hata);

            _contactDal.Add(contact);
            return new SuccessResult();
        }

        public IDataResult<List<Contact>> GetList()
        {
            return new SuccessDataResult<List<Contact>>(_contactDal.GetList());
        }

        private IResult CheckEntityBlank(Contact contact)
        {
            if (contact == null)
            {
                return new ErrorResult(Messages.Hata);
            }

            return new SuccessResult();
        }
    }
}