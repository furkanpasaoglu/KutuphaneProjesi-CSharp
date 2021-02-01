using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Kutuphane.Entities.Concrete;

namespace Kutuphane.Business.Abstract
{
    public interface IMemberService
    {
        List<Member> GetList(Func<Member, bool> filter = null, params Expression<Func<Member, object>>[] include);
        Member GetById(int id);
        void Add(Member member);
        void Update(Member member);
        void Delete(Member member);
    }
}