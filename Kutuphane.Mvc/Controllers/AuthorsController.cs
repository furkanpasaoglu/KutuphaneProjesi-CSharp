using Kutuphane.Business.Abstract;
using Kutuphane.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Kutuphane.MVC.Controllers
{
    public class AuthorsController : Controller
    {
        private IAuthorService _authorService;

        public AuthorsController(IAuthorService writerService)
        {
            _authorService = writerService;
        }

        public IActionResult Index(string p,int page = 1)
        {
            return View(_authorService.GetList(p).ToPagedList(page, 3));
        }

        [HttpGet]
        public IActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAuthor(Author author)
        {
            _authorService.Add(author);
            TempData["Mesaj"] = author.Name + " Adlı Yazar Eklendi!";
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAuthor(int id)
        {
            var query = _authorService.GetById(id);
            _authorService.Delete(query);
            TempData["Mesaj"] = query.Name + " Adlı Yazar Silindi!";
            return RedirectToAction("Index", "Authors");
        }

        [HttpGet]
        public IActionResult UpdateAuthor(int id)
        {
            var query = _authorService.GetById(id);
            return View("UpdateAuthor", query);
        }

        [HttpPost]
        public IActionResult UpdateAuthor(Author author)
        {
            _authorService.Update(author);
            TempData["Mesaj"] = author.Name + " Adlı Yazar Bilgileri Güncellendi!";
            return RedirectToAction("Index");
        }
    }
}
