using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Kutuphane.Business.Abstract;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.Entities.Concrete;

namespace Kutuphane.Business.Concrete
{
    public class MemberManager: IMemberService
    {
        private IMemberDal _memberDal;
        public MemberManager(IMemberDal memberDal)
        {
            _memberDal = memberDal;
        }


        public List<Member> GetList(Func<Member, bool> filter = null, params Expression<Func<Member, object>>[] include)
        {
            return _memberDal.GetList(filter, include);
        }

        public Member GetById(int id)
        {
            return id > 0 ? _memberDal.GetById(p => p.Id == id) : throw new Exception("Hata");
        }

        public void Add(Member member)
        {
            if (member != null)
            {
                _memberDal.Add(member);
            }
            else
            {
                throw new Exception("Hata");
            }
        }

        public void Update(Member member)
        {
            if (member != null)
            {
                _memberDal.Update(member);
            }
            else
            {
                throw new Exception("Hata");
            }
        }

        public void Delete(Member member)
        {
            if (member != null)
            {
                _memberDal.Delete(member);
            }
            else
            {
                throw new Exception("Hata");
            }
        }
    }
}