using System.Collections.Generic;
using Kutuphane.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kutuphane.MVC.Models.ListView
{
    public class BookListViewModel
    {
        public List<Book> Books { get; set; }
        public List<SelectListItem> CategoryListItem { get; set; }
        public List<SelectListItem> AuthorListItem { get; set; }

    }
}