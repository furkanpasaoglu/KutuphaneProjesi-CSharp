using System.Collections.Generic;
using Kutuphane.Business.Abstract;
using Kutuphane.Core.Kutuphane.Aspects.Autofac.Caching;
using Kutuphane.Core.Kutuphane.Utilities.Results;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.Entities.Concrete;

namespace Kutuphane.Business.Concrete
{
    public class AboutManager: IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }
        
        [CacheAspect]
        public IDataResult<List<About>> GetList()
        {
            return new SuccessDataResult<List<About>>(_aboutDal.GetList());
        }
    }
}