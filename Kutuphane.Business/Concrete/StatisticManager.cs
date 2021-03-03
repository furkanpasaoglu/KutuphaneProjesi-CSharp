using System;
using System.Collections.Generic;
using System.Linq;
using Kutuphane.Business.Abstract;
using Kutuphane.Business.Constant;
using Kutuphane.Core.Kutuphane.Utilities.Business;
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
            var result = BusinessRules.Run2(CheckByQueryBlank(p));
            if (result != null)
                return new SuccessDataResult<List<StatisticDetailDto>>(_statisticDal.GetStatisticDetails().Where(x=> x.Status == false).ToList(), Messages.IstatistikListele);

            return new SuccessDataResult<List<StatisticDetailDto>>(_statisticDal.GetStatisticDetails().Where(x => x.MemberName.Contains(p) && x.Status == false).ToList(), Messages.IstatistikListele);
        }
        public IDataResult<StatisticDetailDto> GetStatisticDetails(int bookId, int personalId, int memberId)
        {
            var result = BusinessRules.Run2(CheckByMultipleIdBlank(bookId,personalId,memberId));
            if (result != null)
                return new ErrorDataResult<StatisticDetailDto>(Messages.Hata);

            return new SuccessDataResult<StatisticDetailDto>(_statisticDal.GetStatisticDetails(bookId, personalId, memberId));
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

        public IDataResult<List<Book>> GetBook(bool value)
        {
            return new SuccessDataResult<List<Book>>(_statisticDal.GetBook(value));
        }

        public IDataResult<List<Penaltie>> GetPenaltie()
        {
            return new SuccessDataResult<List<Penaltie>>(_statisticDal.GetPenaltie());
        }

        public IDataResult<decimal> GetPenaltieSum()
        {
            return new SuccessDataResult<decimal>(_statisticDal.GetPenaltieSum());
        }

        public IDataResult<Statistic> GetById(int id)
        {
            var result = BusinessRules.Run2(CheckByIdBlank(id));
            if (result != null)
                return new ErrorDataResult<Statistic>(Messages.Hata);

            return new SuccessDataResult<Statistic>(_statisticDal.Get(p => p.Id == id));
        }

        public IResult Add(Statistic lend)
        {
            var result = BusinessRules.Run(CheckEntityBlank(lend));
            if (result != null)
                return new ErrorResult(Messages.Hata);

            _statisticDal.Add(lend);
            return new SuccessResult(Messages.IstatistikEkle);
        }

        public IResult Update(Statistic lend)
        {
            var result = BusinessRules.Run(CheckEntityBlank(lend));
            if (result != null)
                return new ErrorResult(Messages.Hata);

            _statisticDal.Update(lend);
            return new SuccessResult(Messages.IstatistikGüncelle);
        }
        private IResult CheckEntityBlank(Statistic statistic)
        {
            if (statistic == null)
            {
                return new ErrorResult(Messages.Hata);
            }

            return new SuccessResult();
        }

        private IDataResult<object> CheckByIdBlank(int id)
        {
            if (id > 0)
            {
                return new SuccessDataResult<object>();
            }

            return new ErrorDataResult<object>(Messages.Hata);
        }
        private IDataResult<object> CheckByMultipleIdBlank(int id,int id2,int id3)
        {
            if (id > 0 && id2 > 0 && id3 > 0)
            {
                return new SuccessDataResult<object>();
            }

            return new ErrorDataResult<object>(Messages.Hata);
        }

        private IDataResult<object> CheckByQueryBlank(string p)
        {
            if (!String.IsNullOrEmpty(p))
            {
                return new SuccessDataResult<object>();
            }

            return new ErrorDataResult<object>();
        }

    }
}