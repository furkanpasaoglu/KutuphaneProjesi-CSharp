using System.Collections.Generic;
using Kutuphane.Core.Kutuphane.DataAccess;
using Kutuphane.Entities.Concrete;
using Kutuphane.Entities.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kutuphane.DataAccess.Abstract
{
    public interface IBookDal: IEntityRepository<Book>
    {
        List<BookDetailDto> GetBookDetails();
        List<SelectListItem> GetCategory();
        List<SelectListItem> GetAuthor();
    }
}