using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Kutuphane.Entities.Concrete;
using X.PagedList;

namespace Kutuphane.Business.Abstract
{
    public interface IStatisticService
    {
        IPagedList<Statistic> GetList(int page, int pageSize, Func<Statistic, bool> filter = null,
            params Expression<Func<Statistic, object>>[] include);
        List<Book> GetBookList();
        List<Member> GetMemberList();
        List<Personal> GetPersonalList();
        Statistic GetById(int id);
        //Geçici
        Member GetMemberById(int id);
        Book GetBookById(int id);
        Personal GetPersonalById(int id);

        void Add(Statistic lend);
        void Update(Statistic lend);
    }
}