using System.Collections.Generic;
using Kutuphane.Core.Kutuphane.DataAccess;
using Kutuphane.Entities.Concrete;
using Kutuphane.Entities.DTOs;

namespace Kutuphane.DataAccess.Abstract
{
    public interface IOperationDal : IEntityRepository<Statistic>
    {
        List<StatisticDetailDto> GetStatisticDetails();
        StatisticDetailDto GetStatisticDetails(int bookId, int personalId, int memberId);
    }
}