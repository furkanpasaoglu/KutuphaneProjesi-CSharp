using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Kutuphane.Business.Abstract;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.Entities.Concrete;
using Kutuphane.Entities.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace Kutuphane.Business.Concrete
{
    public class StatisticManager : IStatisticService
    {
        private IStatisticDal _statisticDal;

        public StatisticManager(IStatisticDal statisticDal)
        {
            _statisticDal = statisticDal;
        }

        public List<StatisticDetailDto> GetList(string p = "")
        {
            if (!String.IsNullOrEmpty(p))
            {
                return _statisticDal.GetStatisticDetails().Where(x => x.MemberName.Contains(p)).ToList();
            }
            else
            {
                return _statisticDal.GetStatisticDetails().ToList();
            }
        }
        public StatisticDetailDto GetStatisticDetails(int bookId, int personalId, int memberId)
        {
            return bookId>0 && personalId>0 && memberId>0 ? _statisticDal.GetStatisticDetails(bookId, personalId, memberId) : throw new Exception("Hata");
        }

        public List<SelectListItem> GetMember()
        {
           return _statisticDal.GetMember();
        }

        public List<SelectListItem> GetPersonal()
        {
            return _statisticDal.GetPersonal();
        }

        public List<SelectListItem> GetBook()
        {
            return _statisticDal.GetBook();
        }

        public Statistic GetById(int id)
        {
            return id > 0 ? _statisticDal.GetById(p => p.Id == id) : throw new Exception("Hata");
        }

        public void Add(Statistic lend)
        {
            if (lend != null)
            {
                _statisticDal.Add(lend);
            }
            else
            {
                throw new Exception("Hata");
            }
        }

        public void Update(Statistic lend)
        {
            if (lend != null)
            {
                _statisticDal.Update(lend);
            }
            else
            {
                throw new Exception("Hata");
            }
        }
    }
}