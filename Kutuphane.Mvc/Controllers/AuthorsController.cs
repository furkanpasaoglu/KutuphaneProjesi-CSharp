using System;
using Kutuphane.Business.Abstract;
using Kutuphane.Entities.Concrete;
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

        public IActionResult Index(string p,int page = 1)
        {
            if (!String.IsNullOrEmpty(p) && page>0)
            {
                return View(_authorService.GetList(page, 3, x => x.Name.Contains(p)));
            }
            else
            {
                return View(_authorService.GetList(page, 3));
            }
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
