using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Kutuphane.Entities.Concrete;
using Kutuphane.Entities.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace Kutuphane.Business.Abstract
{
    public interface IStatisticService
    {
        List<StatisticDetailDto> GetList(string p = "");
        List<SelectListItem> GetMember();
        List<SelectListItem> GetPersonal();
        List<SelectListItem> GetBook();
        Statistic GetById(int id);
        StatisticDetailDto GetStatisticDetails(int bookId, int personalId, int memberId);
        void Add(Statistic lend);
        void Update(Statistic lend);
    }
}