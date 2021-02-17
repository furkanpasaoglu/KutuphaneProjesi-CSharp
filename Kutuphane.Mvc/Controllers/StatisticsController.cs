using Kutuphane.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Mvc.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        public IActionResult Index()
        {
            var query1 = _statisticService.GetMember().Data.Count;
            var query2 = _statisticService.GetBook().Data.Count;
            var query3 = _statisticService.GetBook(false).Data.Count;
            var query4 = _statisticService.GetPenaltieSum().Data;
            ViewBag.dgr1 = query1;
            ViewBag.dgr2 = query2;
            ViewBag.dgr3 = query3;
            ViewBag.dgr4 = query4;
            return View();
        }

        public IActionResult CardWeather()
        {
            return View();
        }
        public IActionResult Gallery()
        {
            return View();
        }
    }
}
