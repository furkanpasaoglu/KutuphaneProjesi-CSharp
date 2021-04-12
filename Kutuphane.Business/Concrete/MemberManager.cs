using System;
using System.Collections.Generic;
using System.Linq;
using Kutuphane.Business.Abstract;
using Kutuphane.Business.BusinessAspects.Autofac;
using Kutuphane.Business.Constant;
using Kutuphane.Core.Kutuphane.Entities.Concrete;
using Kutuphane.Core.Kutuphane.Utilities.Business;
using Kutuphane.Core.Kutuphane.Utilities.Results;
using Kutuphane.DataAccess.Abstract;

namespace Kutuphane.Business.Concrete
{
    public class MemberManager : IMemberService
    {
        private readonly IMemberDal _memberDal;
        public MemberManager(IMemberDal memberDal)
        {
            _memberDal = memberDal;
        }

        public IDataResult<List<Member>> GetList(string p = "")
        {
            var result = BusinessRules.Run2(CheckByQueryBlank(p));
            if (result != null)
                return new SuccessDataResult<List<Member>>(_memberDal.GetList().ToList(), Messages.ÜyeListele);

            return new SuccessDataResult<List<Member>>(_memberDal.GetList().Where(x => x.Name.Contains(p)).ToList(), Messages.ÜyeListele);
        }

        public IDataResult<Member> GetById(int id)
        {
            var result = BusinessRules.Run2(CheckByIdBlank(id));
            if (result != null)
                return new ErrorDataResult<Member>(Messages.Hata);

            return new SuccessDataResult<Member>(_memberDal.Get(p => p.Id == id));
        }

        public IResult Add(Member member)
        {
            var result = BusinessRules.Run(CheckEntityBlank(member));
            if (result != null)
                return new ErrorResult(Messages.Hata);

            _memberDal.Add(member);
            return new SuccessResult(Messages.ÜyeEkle);
        }

        public IResult Update(Member member)
        {
            var result = BusinessRules.Run(CheckEntityBlank(member));
            if (result != null)
                return new ErrorResult(Messages.Hata);

            _memberDal.Update(member);
            return new SuccessResult(Messages.ÜyeGüncelle);
        }

        public IResult Delete(Member member)
        {
            var result = BusinessRules.Run(CheckEntityBlank(member));
            if (result != null)
                return new ErrorResult(Messages.Hata);

            _memberDal.Delete(member);
            return new SuccessResult(Messages.ÜyeSil);
        }

        private IResult CheckEntityBlank(Member member)
        {
            if (member == null)
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