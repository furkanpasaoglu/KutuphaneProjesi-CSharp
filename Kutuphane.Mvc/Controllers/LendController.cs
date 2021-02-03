using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kutuphane.Business.Abstract;
using Kutuphane.Core.Kutuphane.Entities;
using Kutuphane.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kutuphane.Mvc.Controllers
{
    public class LendController : Controller
    {
        private IStatisticService _statisticService;

        public LendController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        public IActionResult Index(string p, int page = 1)
        {
            if (!String.IsNullOrEmpty(p) && page > 0)
            {
                return View(_statisticService.GetList(page, 3, x => x.Member.Name.Contains(p), (k => k.Book), (a => a.Member),(p=>p.Personal)));
            }
            else
            {
                return View(_statisticService.GetList(page, 3, null, (k => k.Book), (a => a.Member), (p => p.Personal)));
            }
        }

        [HttpGet]
        public IActionResult Lend()
        {
            var query1 = (from u in _statisticService.GetMemberList()
                select new SelectListItem
                {
                    Text = u.Name + ' '+u.Surname,
                    Value = u.Id.ToString()
                }).ToList();
            var query2 = (from u in _statisticService.GetBookList()
                select new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }).ToList();
            var query3 = (from u in _statisticService.GetPersonalList()
                select new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }).ToList();

            ViewBag.value1 = query1;
            ViewBag.value2 = query2;
            ViewBag.value3 = query3;
            return View();
        }

        [HttpPost]
        public IActionResult Lend(Statistic statistic)
        {
            _statisticService.Add(statistic);
            TempData["Mesaj"] = " Ödünç Verildi!";
            return RedirectToAction("Index");
            //View Yapınca hata patlatıyor bakılacak
        }
        
        [HttpGet]
        public IActionResult ReturnLend(int id)
        {
            var stat = _statisticService.GetById(id);
            var query1 = (from u in _statisticService.GetBookList()
                where
                    u.Id == stat.BookId
                select u).SingleOrDefault();
            var query2 = (from u in _statisticService.GetMemberList()
                where
                    u.Id == stat.MemberId
                select u).SingleOrDefault();
            var query3 = (from u in _statisticService.GetPersonalList()
                where
                    u.Id == stat.PersonalId
                select u).SingleOrDefault();

            stat.Book = query1;
            stat.Member = query2;
            stat.Personal = query3;
            
            return View("ReturnLend",stat);
        }

        [HttpPost]
        public IActionResult ReturnLend(Statistic statistic)
        {
            var stat = _statisticService.GetById(statistic.Id);
            var query1 = (from u in _statisticService.GetBookList()
                          where
                              u.Id == stat.BookId
                          select u).SingleOrDefault();
            var query2 = (from u in _statisticService.GetMemberList()
                          where
                              u.Id == stat.MemberId
                          select u).SingleOrDefault();
            var query3 = (from u in _statisticService.GetPersonalList()
                          where
                              u.Id == stat.PersonalId
                          select u).SingleOrDefault();
            statistic.Book = query1;
            statistic.Member = query2;
            statistic.Personal = query3;
            statistic.Status = true;
            statistic.BookId = query1.Id;
            statistic.MemberId = query2.Id;
            statistic.PersonalId = query3.Id;

            _statisticService.Update(statistic);
            TempData["Mesaj"] = " Kitap Geri Alındı!";
            return RedirectToAction("Index");
        }
    }
}
