using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kutuphane.Business.Abstract;
using Kutuphane.Entities.Concrete;
using Kutuphane.MVC.Models.ListView;
using X.PagedList;

namespace Kutuphane.MVC.Controllers
{
    public class PersonalsController : Controller
    {
        private readonly IPersonalService _personalService;

        public PersonalsController(IPersonalService personalService)
        {
            _personalService = personalService;
        }
        public IActionResult Index(string p, int page = 1)
        {
            return View(_personalService.GetList(p).Data.ToPagedList(page, 3));
        }

        [HttpGet]
        public IActionResult AddPersonal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPersonal(Personal personal)
        {
            if (!ModelState.IsValid)
            {
                return View("AddPersonal");
            }
            _personalService.Add(personal);
            TempData["Mesaj"] = personal.Name + " Personel Eklendi!";
            return RedirectToAction("Index");
        }

        public IActionResult DeletePersonal(int id)
        {
            var query = _personalService.GetById(id).Data;
            _personalService.Delete(query);
            TempData["Mesaj"] = query.Name + " Personel Silindi!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdatePersonal(int id)
        {
            var query = _personalService.GetById(id).Data;
            return View("UpdatePersonal", query);
        }

        [HttpPost]
        public IActionResult UpdatePersonal(Personal personal)
        {
            _personalService.Update(personal);
            TempData["Mesaj"] = personal.Name + " Personel Bilgileri Güncellendi!";
            return RedirectToAction("Index");

        }
    }
}
