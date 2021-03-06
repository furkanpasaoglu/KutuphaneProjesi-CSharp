using System.Collections.Generic;
using System.Linq;
using Kutuphane.Core.Kutuphane.DataAccess.EntityFramework;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.DataAccess.Concrete.EntityFramework.Context;
using Kutuphane.Entities.Concrete;
using Kutuphane.Entities.DTOs;

namespace Kutuphane.DataAccess.Concrete.EntityFramework
{
    public class EfOperationDal : EfEntityRepositoryBase<Statistic, KutuphaneContext>, IOperationDal
    {
        public List<StatisticDetailDto> GetStatisticDetails()
        {
            using (KutuphaneContext context = new KutuphaneContext())
            {
                var query = (from u in context.Statistics
                    join b in context.Books on u.BookId equals b.Id
                    join p in context.Personals on u.PersonalId equals p.Id
                    join m in context.Members on u.MemberId equals m.Id
                    select new StatisticDetailDto
                    {
                        Id = u.Id,
                        BookId = b.Id,
                        BookName = b.Name,
                        PersonalId = p.Id,
                        PersonalName = p.Name,
                        MemberId = m.Id,
                        MemberName = m.Name,
                        MemberSurname = m.Surname,
                        DateofPurchase = u.DateofPurchase,
                        DateofReturn = u.DateofReturn,
                        MemberDate = u.MemberDate,
                        Status = u.Status
                    });
                return query.ToList();
            }
        }

        public StatisticDetailDto GetStatisticDetails(int bookId, int personalId, int memberId)
        {
            using (KutuphaneContext context = new KutuphaneContext())
            {
                var query = (from u in context.Statistics
                    join b in context.Books on u.BookId equals b.Id
                    join p in context.Personals on u.PersonalId equals p.Id
                    join m in context.Members on u.MemberId equals m.Id
                    where u.BookId == bookId && u.MemberId == memberId && u.PersonalId == personalId
                    select new StatisticDetailDto
                    {
                        Id = u.Id,
                        BookId = b.Id,
                        BookName = b.Name,
                        PersonalId = p.Id,
                        PersonalName = p.Name,
                        MemberId = m.Id,
                        MemberName = m.Name,
                        MemberSurname = m.Surname,
                        DateofPurchase = u.DateofPurchase,
                        DateofReturn = u.DateofReturn,
                        MemberDate = u.MemberDate,
                        Status = u.Status
                    });
                return query.SingleOrDefault();
            }
        }
    }
}