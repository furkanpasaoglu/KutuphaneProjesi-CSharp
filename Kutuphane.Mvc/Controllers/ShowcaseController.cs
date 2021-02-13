using Kutuphane.Business.Abstract;
using Kutuphane.Entities.Concrete;
using Kutuphane.MVC.Models.ListView;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Kutuphane.Mvc.Controllers
{
    public class ShowcaseController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAboutService _aboutService;
        private readonly IContactService _contactService;

        public ShowcaseController(IBookService bookService, IAboutService aboutService, IContactService contactService)
        {
            _bookService = bookService;
            _aboutService = aboutService;
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cl = new ShowcaseListViewModel
            {
                Books=_bookService.GetList().Data,
                Abouts = _aboutService.GetList().Data
            };
            return View(cl);
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
             _contactService.Add(contact);
             return RedirectToAction("Index");
        }
    }
}
