using System;
using System.Collections.Generic;
using System.Linq;
using Kutuphane.Business.Abstract;
using Kutuphane.Business.Constant;
using Kutuphane.Core.Kutuphane.Utilities.Results;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.Entities.Concrete;

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
            if (!String.IsNullOrEmpty(p))
            {
                return new SuccessDataResult<List<Member>>(_memberDal.GetList().Where(x => x.Name.Contains(p)).ToList(), Messages.ÜyeListele);
            }
            return new SuccessDataResult<List<Member>>(_memberDal.GetList().ToList(), Messages.ÜyeListele);
        }

        public IDataResult<Member> GetById(int id)
        {
            if (id > 0)
            {
                return new SuccessDataResult<Member>(_memberDal.GetById(p => p.Id == id));
            }
            return new ErrorDataResult<Member>(Messages.Hata);
        }

        public IResult Add(Member member)
        {
            if (member != null)
            {
                _memberDal.Add(member);
                return new SuccessResult(Messages.ÜyeEkle);
            }

            return new ErrorDataResult<Member>(Messages.Hata);
        }

        public IResult Update(Member member)
        {
            if (member != null)
            {
                _memberDal.Update(member);
                return new SuccessResult(Messages.ÜyeGüncelle);
            }
            return new ErrorDataResult<Member>(Messages.Hata);
        }

        public IResult Delete(Member member)
        {
            if (member != null)
            {
                _memberDal.Delete(member);
                return new SuccessResult(Messages.ÜyeSil);
            }
            return new ErrorDataResult<Member>(Messages.Hata);
        }
    }
}