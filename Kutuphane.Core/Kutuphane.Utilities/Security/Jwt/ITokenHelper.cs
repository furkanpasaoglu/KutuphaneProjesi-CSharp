using System.Collections.Generic;
using Kutuphane.Core.Kutuphane.Entities.Concrete;

namespace Kutuphane.Core.Kutuphane.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(Member member, List<OperationClaim> operationClaims);
    }
}