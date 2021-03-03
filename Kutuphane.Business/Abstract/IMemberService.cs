using System.Collections.Generic;
using Kutuphane.Core.Kutuphane.Entities.Concrete;
using Kutuphane.Core.Kutuphane.Utilities.Results;
using Kutuphane.Entities.Concrete;

namespace Kutuphane.Business.Abstract
{
    public interface IMemberService
    {
        IDataResult<List<Member>> GetList(string p = "");
        IDataResult<Member> GetById(int id);
        IResult Add(Member member);
        IResult Update(Member member);
        IResult Delete(Member member);
    }
}