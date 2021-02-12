using System;
using System.Collections.Generic;
using System.Linq;
using Kutuphane.Business.Abstract;
using Kutuphane.Business.Constant;
using Kutuphane.Core.Kutuphane.Utilities.Results;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.Entities.Concrete;
using Kutuphane.Entities.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kutuphane.Business.Concrete
{
    public class StatisticManager : IStatisticService
    {
        private readonly IStatisticDal _statisticDal;

        public StatisticManager(IStatisticDal statisticDal)
        {
            _statisticDal = statisticDal;
        }

        public IDataResult<List<StatisticDetailDto>> GetList(string p = "")
        {
            if (!String.IsNullOrEmpty(p))
            {
                return new SuccessDataResult<List<StatisticDetailDto>>(_statisticDal.GetStatisticDetails().Where(x => x.MemberName.Contains(p)).ToList(), Messages.IstatistikListele);
            }
            return new SuccessDataResult<List<StatisticDetailDto>>(_statisticDal.GetStatisticDetails().ToList(), Messages.IstatistikListele);
        }
        public IDataResult<StatisticDetailDto> GetStatisticDetails(int bookId, int personalId, int memberId)
        {
            if (bookId > 0 && personalId > 0 && memberId > 0)
            {
                return new SuccessDataResult<StatisticDetailDto>(_statisticDal.GetStatisticDetails(bookId, personalId, memberId));
            }

            return new ErrorDataResult<StatisticDetailDto>(Messages.Hata);
        }

        public IDataResult<List<SelectListItem>> GetMember()
        {
            return new SuccessDataResult<List<SelectListItem>>(_statisticDal.GetMember());
        }

        public IDataResult<List<SelectListItem>> GetPersonal()
        {
            return new SuccessDataResult<List<SelectListItem>>(_statisticDal.GetPersonal());
        }

        public IDataResult<List<SelectListItem>> GetBook()
        {
            return new SuccessDataResult<List<SelectListItem>>(_statisticDal.GetBook());
        }

        public IDataResult<Statistic> GetById(int id)
        {
            if (id > 0)
            {
                return new SuccessDataResult<Statistic>(_statisticDal.GetById(p => p.Id == id));
            }
            return new ErrorDataResult<Statistic>(Messages.Hata);
        }

        public IResult Add(Statistic lend)
        {
            if (lend != null)
            {
                _statisticDal.Add(lend);
                return new SuccessResult(Messages.IstatistikEkle);
            }

            return new ErrorResult(Messages.Hata);

        }

        public IResult Update(Statistic lend)
        {
            if (lend != null)
            {
                _statisticDal.Update(lend);
                return new SuccessResult(Messages.IstatistikGüncelle);
            }
            return new ErrorResult(Messages.Hata);
        }
    }
}