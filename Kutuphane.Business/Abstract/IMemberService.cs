using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Kutuphane.Entities.Concrete;
using X.PagedList;

namespace Kutuphane.Business.Abstract
{
    public interface IMemberService
    {
        List<Member> GetList(string p = "");
        Member GetById(int id);
        void Add(Member member);
        void Update(Member member);
        void Delete(Member member);
    }
}