using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Kutuphane.Core.Kutuphane.Utilities.Results;
using Kutuphane.Entities.Concrete;
using Kutuphane.Entities.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kutuphane.Business.Abstract
{
    public interface IStatisticService
    {
        IDataResult<List<StatisticDetailDto>> GetList(string p = "");
        IDataResult<List<SelectListItem>> GetMember();
        IDataResult<List<SelectListItem>> GetPersonal();
        IDataResult<List<SelectListItem>> GetBook();
        IDataResult<Statistic> GetById(int id);
        IDataResult<StatisticDetailDto> GetStatisticDetails(int bookId, int personalId, int memberId);
        IResult Add(Statistic lend);
        IResult Update(Statistic lend);
    }
}