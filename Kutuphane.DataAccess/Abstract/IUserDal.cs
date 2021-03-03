using System.Collections.Generic;
using Kutuphane.Core.Kutuphane.DataAccess;
using Kutuphane.Core.Kutuphane.Entities.Concrete;

namespace Kutuphane.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<Member>
    {
        List<OperationClaim> GetClaims(Member member);
    }
}