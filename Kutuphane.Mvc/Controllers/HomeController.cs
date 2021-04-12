using Kutuphane.Business.Abstract;
using Kutuphane.Business.BusinessAspects.Autofac;
using Kutuphane.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
namespace Kutuphane.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
          
        }
    }
}
