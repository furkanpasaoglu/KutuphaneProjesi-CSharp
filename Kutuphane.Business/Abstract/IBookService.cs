using System.Collections.Generic;
using Kutuphane.Entities.Concrete;
using Kutuphane.Entities.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kutuphane.Business.Abstract
{
    public interface IBookService
    {
        List<BookDetailDto> GetList(string p = "");
        List<SelectListItem> GetCategory();
        List<SelectListItem> GetAuthor();
        Book GetById(int id);
        void Add(Book book);
        void Update(Book book);
        void Delete(Book book);
    }
}