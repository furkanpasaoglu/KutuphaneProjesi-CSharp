using System.Collections.Generic;
using Kutuphane.Entities.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace Kutuphane.MVC.Models.ListView
{
    public class BookListViewModel
    {
        public IPagedList<BookDetailDto> BookDetailDto { get; set; }
    }
}