using Microsoft.AspNetCore.Mvc;
using Kutuphane.Business.Abstract;
using Kutuphane.Entities.Concrete;

namespace Kutuphane.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Get()
        {
            var result = _contactService.GetList();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Add(Contact contact)
        {
            var result = _contactService.Add(contact);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
