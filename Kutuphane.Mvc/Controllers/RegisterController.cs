using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kutuphane.Business.Abstract;
using Kutuphane.Entities.DTOs;

namespace Kutuphane.Mvc.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IAuthService _authService;
        public RegisterController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserForRegisterDto userForRegisterDto)
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
