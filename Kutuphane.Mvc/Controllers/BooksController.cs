using Kutuphane.Business.Abstract;
using Kutuphane.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
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
            return View(_bookService.GetList(p).ToPagedList(page, 3));
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            ViewBag.value = _bookService.GetCategory();
            ViewBag.value2 = _bookService.GetAuthor();
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _bookService.Add(book);
            TempData["Mesaj"] = book.Name + " Kitap Eklendi!";
            return RedirectToAction("Index", "Books");
            //View Yapınca hata patlatıyor bakılacak
        }

        public IActionResult DeleteBook(int id)
        {
            var query = _bookService.GetById(id);
            _bookService.Delete(query);
            TempData["Mesaj"] = query.Name + " Kitap Silindi!";
            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        public IActionResult UpdateBook(int id)
        {
            ViewBag.value = _bookService.GetCategory();
            ViewBag.value2 = _bookService.GetAuthor();
            var query = _bookService.GetById(id);
            return View("UpdateBook",query);
        }

        [HttpPost]
        public IActionResult UpdateBook(Book book)
        {
            //Kontrol Edilecek
            //book.CategoryId = book.Category.Id;
            //book.AuthorId = book.Author.Id;
            _bookService.Update(book);
            TempData["Mesaj"] = book.Name + " Kitap Bilgileri Güncellendi!";
            return RedirectToAction("Index", "Books");
        }
    }
}
