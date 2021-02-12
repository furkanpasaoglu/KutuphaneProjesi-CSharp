using System.Collections.Generic;
using Kutuphane.Core.Kutuphane.Utilities.Results;
using Kutuphane.Entities.Concrete;

namespace Kutuphane.Business.Abstract
{
    public interface IPersonalService
    {
        IDataResult<List<Personal>> GetList(string p = "");
        IDataResult<Personal> GetById(int id);
        IResult Add(Personal personal);
        IResult Update(Personal personal);
        IResult Delete(Personal personal);
    }
}