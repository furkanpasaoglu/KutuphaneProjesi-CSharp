using System.Collections.Generic;
using Kutuphane.Entities.Concrete;
using Kutuphane.Entities.DTOs;

namespace Kutuphane.MVC.Models.ListView
{
    public class ShowcaseListViewModel
    {
        public List<BookDetailDto> Books { get; set; }
        public List<About> Abouts { get; set; }
    }
}