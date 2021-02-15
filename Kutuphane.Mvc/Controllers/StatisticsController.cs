using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Mvc.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Weather()
        {
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
