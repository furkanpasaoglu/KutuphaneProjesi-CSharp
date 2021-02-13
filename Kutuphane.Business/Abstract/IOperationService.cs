using System.Collections.Generic;
using Kutuphane.Core.Kutuphane.Utilities.Results;
using Kutuphane.Entities.DTOs;

namespace Kutuphane.Business.Abstract
{
    public interface IOperationService
    {
         IDataResult<List<StatisticDetailDto>> GetAll(string p = "");
    }
}