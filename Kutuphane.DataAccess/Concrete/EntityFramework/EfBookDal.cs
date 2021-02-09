using System.Collections.Generic;
using System.Linq;
using Kutuphane.Core.Kutuphane.DataAccess.EntityFramework;
using Kutuphane.DataAccess.Abstract;
using Kutuphane.DataAccess.Concrete.EntityFramework.Context;
using Kutuphane.Entities.Concrete;
using Kutuphane.Entities.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kutuphane.DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : EfEntityRepositoryBase<Book, KutuphaneContext>, IBookDal
    {
        public List<BookDetailDto> GetBookDetails()
        {
            using (KutuphaneContext context = new KutuphaneContext())
            {
                var query = (from b in context.Books
                    join c in context.Categories on b.CategoryId equals c.Id
                    join a in context.Authors on b.AuthorId equals a.Id
                    select new BookDetailDto
                    {
                        Id = b.Id,
                        CategoryId = c.Id,
                        AuthorId = a.Id,
                        Name = b.Name,
                        CategoryName = c.Name,
                        AuthorName = a.Name,
                        AuthorSurname = a.Surname,
                        YearofPublication = b.YearofPublication,
                        PublishingHouse = b.PublishingHouse,
                        Page = b.Page,
                        Status = b.Status
                    });
                return query.ToList();
            }
        }

        public List<SelectListItem> GetCategory()
        {
            using (KutuphaneContext context = new KutuphaneContext())
            {
                var query = (from u in context.Categories
                              select new SelectListItem
                              {
                                  Text = u.Name,
                                  Value = u.Id.ToString()
                              }).ToList();
                return query;
            }
        }

        public List<SelectListItem> GetAuthor()
        {
            using (KutuphaneContext context = new KutuphaneContext())
            {
                var query = (from u in context.Authors
                    select new SelectListItem
                    {
                        Text = u.Name + ' ' + u.Surname,
                        Value = u.Id.ToString()
                    }).ToList();
                return query.ToList();
            }
        }

    }
}