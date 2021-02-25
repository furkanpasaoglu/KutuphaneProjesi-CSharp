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

namespace Kutuphane.Business.Concrete
{
    public class OperationManager : IOperationService
    {
        private readonly IOperationDal _operationDal;

        public OperationManager(IOperationDal operationDal)
        {
            _operationDal = operationDal;
        }

        public IDataResult<List<StatisticDetailDto>> GetAll(string p ="")
        {
            var result = BusinessRules.Run2(CheckByQueryBlank(p));
            if (result != null)
                return new SuccessDataResult<List<StatisticDetailDto>>(_operationDal.GetStatisticDetails().Where(x => x.Status == true).ToList(), Messages.IstatistikListele);

            return new SuccessDataResult<List<StatisticDetailDto>>(_operationDal.GetStatisticDetails().Where(x => x.MemberName.Contains(p) && x.Status == true).ToList(), Messages.IstatistikListele);
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