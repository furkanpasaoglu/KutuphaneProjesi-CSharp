using System;
using Kutuphane.Business.Abstract;
using Kutuphane.Entities.Concrete;
using Kutuphane.MVC.Models.ListView;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.MVC.Controllers
{
    public class AuthorsController : Controller
    {
        private IAuthorService _authorService;

        public AuthorsController(IAuthorService writerService)
        {
            _authorService = writerService;
        }

        public IActionResult Index(string p)
        {
            var query = new AuthorListViewModel
            {
                Authors = !String.IsNullOrEmpty(p) ?
                    _authorService.GetList(x => x.Name.Contains(p)) : _authorService.GetList()
            };
            return View(query);
        }

        [HttpGet]
        public IActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAuthor(Author writer)
        {
            _authorService.Add(writer);
            TempData["Mesaj"] = writer.Name + " Adlı Yazar Eklendi!";
            return View();
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
        public IActionResult UpdateAuthor(Author writer)
        {
            _authorService.Update(writer);
            TempData["Mesaj"] = writer.Name + " Adlı Yazar Bilgileri Güncellendi!";
            return View();
        }
    }
}
