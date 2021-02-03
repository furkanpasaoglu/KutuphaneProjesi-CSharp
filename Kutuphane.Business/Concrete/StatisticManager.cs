using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Kutuphane.Business.Abstract;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.Entities.Concrete;
using X.PagedList;

namespace Kutuphane.Business.Concrete
{
    public class StatisticManager : IStatisticService
    {
        private IStatisticDal _statisticDal;
        private IMemberDal _memberDal;
        private IBookDal _bookDal;
        private IPersonalDal _personalDal;

        public StatisticManager(IStatisticDal statisticDal, IMemberDal memberDal, IBookDal bookDal, IPersonalDal personalDal)
        {
            _statisticDal = statisticDal;
            _memberDal = memberDal;
            _bookDal = bookDal;
            _personalDal = personalDal;
        }

        public IPagedList<Statistic> GetList(int page, int pageSize, Func<Statistic, bool> filter = null, params Expression<Func<Statistic, object>>[] include)
        {
            if (page > 0 && pageSize > 0)
            {
                return _statisticDal.GetList(filter, include).ToPagedList(page, pageSize);
            }
            else
            {
                return _statisticDal.GetList(filter, include).ToPagedList(page, pageSize);
            }
        }

        public List<Book> GetBookList()
        {
            return _bookDal.GetList();
        }

        public List<Member> GetMemberList()
        {
            return _memberDal.GetList();
        }

        public List<Personal> GetPersonalList()
        {
            return _personalDal.GetList();
        }

        public Statistic GetById(int id)
        {
            return id > 0 ? _statisticDal.GetById(p => p.Id == id) : throw new Exception("Hata");
        }

        public Member GetMemberById(int id)
        {
            return id > 0 ? _memberDal.GetById(p => p.Id == id) : throw new Exception("Hata");
        }

        public Book GetBookById(int id)
        {
            return id > 0 ? _bookDal.GetById(p => p.Id == id) : throw new Exception("Hata");
        }

        public Personal GetPersonalById(int id)
        {
            return id > 0 ? _personalDal.GetById(p => p.Id == id) : throw new Exception("Hata");
        }


        public void Add(Statistic lend)
        {
            if (lend != null)
            {
                _statisticDal.Add(lend);
            }
            else
            {
                throw new Exception("Hata");
            }
        }

        public void Update(Statistic lend)
        {
            if (lend != null)
            {
                _statisticDal.Update(lend);
            }
            else
            {
                throw new Exception("Hata");
            }
        }
    }
}