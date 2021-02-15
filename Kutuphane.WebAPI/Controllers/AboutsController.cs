using Microsoft.AspNetCore.Mvc;
using Kutuphane.Business.Abstract;

namespace Kutuphane.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutsController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Get()
        {
            var result = _aboutService.GetList();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
