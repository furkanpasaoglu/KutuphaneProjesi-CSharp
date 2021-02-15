using Microsoft.AspNetCore.Mvc;
using Kutuphane.Business.Abstract;
using Kutuphane.Entities.Concrete;

namespace Kutuphane.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }


        [HttpGet]
        [Route("[action]")]
        public IActionResult Get()
        {
            var result = _statisticService.GetList();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult Get(int id)
        {
            var result = _statisticService.GetById(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Add(Statistic statistic)
        {
            var result = _statisticService.Add(statistic);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult Update(Statistic statistic)
        {
            var result = _statisticService.Update(statistic);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetPersonal()
        {
            var result = _statisticService.GetPersonal();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetMember()
        {
            var result = _statisticService.GetMember();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetBook()
        {
            var result = _statisticService.GetBook();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
