using Kutuphane.Business.Abstract;
using Kutuphane.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Kutuphane.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthService _authService;
        private static bool _check = false;
        public HomeController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            ViewBag.data = "";
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                TempData["Class"] = "alert alert-danger alert-dismissible";
                TempData["mesaj"] = userToLogin.Message;
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                TempData["Class"] = "alert alert-success alert-dismissible";
                TempData["mesaj"] = "Başarıyla Giriş Yapıldı";
            }

            return View();
        }

        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                TempData["Class"] = "alert alert-danger alert-dismissible";
                TempData["mesaj"] = userExists.Message;
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                TempData["Class"] = "alert alert-success alert-dismissible";
                TempData["mesaj"] = "Başarıyla Hesabınız Oluşturuldu";
            }
            return View();
        }

    }
}
