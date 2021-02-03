using Kutuphane.Core.Kutuphane.DataAccess.EntityFramework;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.DataAccess.Concrete.EntityFramework.Context;
using Kutuphane.Entities.Concrete;

namespace Kutuphane.DataAccess.Concrete.EntityFramework
{
    public class EfStatisticDal : EfEntityRepositoryBase<Statistic, KutuphaneContext>, IStatisticDal
    {
        
    }
}