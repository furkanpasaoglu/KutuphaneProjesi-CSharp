using System.Collections.Generic;
using Kutuphane.Business.Abstract;
using Kutuphane.Core.Kutuphane.Entities.Concrete;
using Kutuphane.Core.Kutuphane.Utilities.Results;
using Kutuphane.DataAccess.Abstract;

namespace Kutuphane.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<OperationClaim>> GetClaims(Member member)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(member));
        }

        public IDataResult<Member> GetByMail(string email)
        {
            return new SuccessDataResult<Member>(_userDal.Get(p => p.Mail == email));
        }

        public IResult Add(Member member)
        {
            _userDal.Add(member);
            return new SuccessResult();
        }
    }
}