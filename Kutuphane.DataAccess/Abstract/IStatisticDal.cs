using System.Collections.Generic;
using Kutuphane.Core.Kutuphane.DataAccess;
using Kutuphane.Entities.Concrete;
using Kutuphane.Entities.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kutuphane.DataAccess.Abstract
{
    public interface IStatisticDal: IEntityRepository<Statistic>
    {
        List<StatisticDetailDto> GetStatisticDetails();
        StatisticDetailDto GetStatisticDetails(int bookId, int personalId, int memberId);
        List<SelectListItem> GetBook();
        List<Book> GetBook(bool value);
        List<Penaltie> GetPenaltie();
        decimal GetPenaltieSum();
        List<SelectListItem> GetPersonal();
        List<SelectListItem> GetMember();
    }
}