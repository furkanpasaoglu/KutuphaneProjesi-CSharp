using System.Collections.Generic;
using System.Linq;
using Kutuphane.Core.Kutuphane.DataAccess.EntityFramework;
using Kutuphane.Core.Kutuphane.Entities.Concrete;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.DataAccess.Concrete.EntityFramework.Context;

namespace Kutuphane.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<Member, KutuphaneContext>,IUserDal
    {
        public List<OperationClaim> GetClaims(Member member)
        {
            using (var context = new KutuphaneContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.MemberId == member.Id
                    select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}