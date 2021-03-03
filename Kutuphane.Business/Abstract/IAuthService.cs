using Kutuphane.Core.Kutuphane.Entities.Concrete;
using Kutuphane.Core.Kutuphane.Utilities.Results;
using Kutuphane.Core.Kutuphane.Utilities.Security.Jwt;
using Kutuphane.Entities.DTOs;

namespace Kutuphane.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<Member> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<Member> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(Member member);
    }
}