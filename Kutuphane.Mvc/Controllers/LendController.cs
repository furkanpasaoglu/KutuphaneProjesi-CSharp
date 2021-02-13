using System;
using Microsoft.AspNetCore.Mvc;
using Kutuphane.Business.Abstract;
using Kutuphane.Entities.Concrete;
using Kutuphane.Entities.DTOs;
using X.PagedList;

namespace Kutuphane.Mvc.Controllers
{
    public class LendController : Controller
    {
        private readonly IStatisticService _statisticService;

        public LendController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        public IActionResult Index(string p, int page = 1)
        {
            return View(_statisticService.GetList(p).Data.ToPagedList(page, 3));
        }

        [HttpGet]
        public IActionResult Lend()
        {
            ViewBag.value1 = _statisticService.GetMember().Data;
            ViewBag.value2 = _statisticService.GetBook().Data;
            ViewBag.value3 = _statisticService.GetPersonal().Data;
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
            var stat = _statisticService.GetById(id).Data;
            var query = _statisticService.GetStatisticDetails(stat.BookId, stat.PersonalId, stat.MemberId).Data;
            return View("ReturnLend",query); 
        }

        [HttpPost]
        public IActionResult ReturnLend(StatisticDetailDto statistic)
        {
            var stat = _statisticService.GetById(statistic.Id).Data;
            stat.MemberDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            stat.Status = true;
            _statisticService.Update(stat);
            TempData["Mesaj"] = " Kitap Geri Alındı!";
            return RedirectToAction("Index");
        }
    }
}
