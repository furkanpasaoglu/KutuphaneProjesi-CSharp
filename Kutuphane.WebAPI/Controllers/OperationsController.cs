using Microsoft.AspNetCore.Mvc;
using Kutuphane.Business.Abstract;

namespace Kutuphane.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly IOperationService _operationService;

        public OperationsController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Get()
        {
            var result = _operationService.GetAll();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
