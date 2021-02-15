using System.Collections.Generic;
using Kutuphane.Core.Kutuphane.Utilities.Results;
using Kutuphane.Entities.Concrete;

namespace Kutuphane.Business.Abstract
{
    public interface IContactService
    {
        IResult Add(Contact contact);
        IDataResult<List<Contact>> GetList();
    }
}