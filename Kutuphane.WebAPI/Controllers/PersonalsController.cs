using Microsoft.AspNetCore.Mvc;
using Kutuphane.Business.Abstract;
using Kutuphane.Entities.Concrete;

namespace Kutuphane.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalsController : ControllerBase
    {
        private readonly IPersonalService _personalService;

        public PersonalsController(IPersonalService personalService)
        {
            _personalService = personalService;
        }


        [HttpGet]
        [Route("[action]")]
        public IActionResult Get()
        {
            var result = _personalService.GetList();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult Get(int id)
        {
            var result = _personalService.GetById(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Add(Personal personal)
        {
            var result = _personalService.Add(personal);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult Update(Personal personal)
        {
            var result = _personalService.Update(personal);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(Personal personal)
        {
            var result = _personalService.Delete(personal);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
