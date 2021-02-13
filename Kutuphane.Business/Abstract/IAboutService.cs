using System.Collections.Generic;
using Kutuphane.Core.Kutuphane.Utilities.Results;
using Kutuphane.Entities.Concrete;

namespace Kutuphane.Business.Abstract
{
    public interface IAboutService
    {
        IDataResult<List<About>> GetList();
    }
}