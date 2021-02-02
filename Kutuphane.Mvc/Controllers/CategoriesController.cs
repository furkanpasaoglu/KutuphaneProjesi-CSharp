using System;
using Microsoft.AspNetCore.Mvc;
using Kutuphane.Business.Abstract;
using Kutuphane.Entities.Concrete;
using Kutuphane.MVC.Models.ListView;
using X.PagedList;

namespace Kutuphane.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index(string p, int page = 1)
        {
            if (!String.IsNullOrEmpty(p) && page > 0)
            {
                return View(_categoryService.GetList(page, 3, x => x.Name.Contains(p)));
            }
            else
            {
                return View(_categoryService.GetList(page, 3));
            }
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _categoryService.Add(category);
            TempData["Mesaj"] = category.Name+" Kategorisi Eklendi!";
            return View();
        }

        public IActionResult DeleteCategory(int id)
        {
            var query = _categoryService.GetById(id);
            _categoryService.Delete(query);
            TempData["Mesaj"] = query.Name + " Kategorisi Silindi!";
            return RedirectToAction("Index", "Categories");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var query = _categoryService.GetById(id);
            return View("UpdateCategory", query);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.Update(category);
            TempData["Mesaj"] = category.Name + " Kategori Bilgileri Güncellendi!";
            return View();
        }
    }
}
