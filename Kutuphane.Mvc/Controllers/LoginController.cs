using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kutuphane.Business.Abstract;
using Kutuphane.Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Kutuphane.Mvc.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthService _authService;
        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                TempData["Class"] = "alert alert-danger alert-dismissible";
                TempData["mesaj"] = userToLogin.Message;
                return View();
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            HttpContext.Session.SetString("token",result.Data.Token);
            if (result.Success)
            {
                TempData["Class"] = "alert alert-success alert-dismissible";
                TempData["mesaj"] = "Başarıyla Giriş Yapıldı";
                return View();
            }

            return View();

        }
    }
}
