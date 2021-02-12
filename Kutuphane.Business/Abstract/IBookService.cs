using System.Collections.Generic;
using Kutuphane.Core.Kutuphane.Utilities.Results;
using Kutuphane.Entities.Concrete;
using Kutuphane.Entities.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kutuphane.Business.Abstract
{
    public interface IBookService
    {
        IDataResult<List<BookDetailDto>> GetList(string p = "");
        IDataResult<List<SelectListItem>> GetCategory();
        IDataResult<List<SelectListItem>> GetAuthor();
        IDataResult<Book> GetById(int id);
        IResult Add(Book book);
        IResult Update(Book book);
        IResult Delete(Book book);
    }
}