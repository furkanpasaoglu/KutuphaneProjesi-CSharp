using System;
using System.Linq;
using Kutuphane.Business.Abstract;
using Kutuphane.Entities.Concrete;
using Kutuphane.MVC.Models.ListView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace Kutuphane.MVC.Controllers
{
    public class BooksController : Controller
    {
        private IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index(string p, int page = 1)
        {
            if (!String.IsNullOrEmpty(p) && page > 0)
            {
                return View(_bookService.GetList(page, 3, x => x.Name.Contains(p), (k => k.Category), (a => a.Author)));
            }
            else
            {
                return View(_bookService.GetList(page, 3,null, k => k.Category, a => a.Author));
            }
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            var query2 = (from u in _bookService.GetCategoryList()
                select new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }).ToList();
            var query3 = (from u in _bookService.GetAuthorList()
                select new SelectListItem
                {
                    Text = u.Name + ' ' + u.Surname,
                    Value = u.Id.ToString()
                }).ToList();

            ViewBag.value = query2;
            ViewBag.value2 = query3;
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _bookService.Add(book);
            TempData["Mesaj"] = book.Name + " Kategorisi Eklendi!";
            return RedirectToAction("Index");
            //View Yapınca hata patlatıyor bakılacak
        }

        public IActionResult DeleteBook(int id)
        {
            var query = _bookService.GetById(id);
            _bookService.Delete(query);
            TempData["Mesaj"] = query.Name + " Kategorisi Silindi!";
            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        public IActionResult UpdateBook(int id)
        {
            var query = _bookService.GetById(id);
            var query2 = (from u in _bookService.GetCategoryList()
                select new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }).ToList();
            var query3 = (from u in _bookService.GetAuthorList()
                select new SelectListItem
                {
                    Text = u.Name + ' ' + u.Surname,
                    Value = u.Id.ToString()
                }).ToList();
            ViewBag.value = query2;
            ViewBag.value2 = query3;
            return View("UpdateBook", query);
        }

        [HttpPost]
        public IActionResult UpdateBook(Book book)
        {
            book.CategoryId = book.Category.Id;
            book.AuthorId = book.Author.Id;
            _bookService.Update(book);
            TempData["Mesaj"] = book.Name + " Kitap Bilgileri Güncellendi!";
            return RedirectToAction("Index", "Books");
        }
    }
}
