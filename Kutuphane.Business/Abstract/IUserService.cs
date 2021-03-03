using System.Collections.Generic;
using Kutuphane.Core.Kutuphane.Entities.Concrete;
using Kutuphane.Core.Kutuphane.Utilities.Results;

namespace Kutuphane.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(Member member);
        IDataResult<Member> GetByMail(string email);
        IResult Add(Member member);
    }
}