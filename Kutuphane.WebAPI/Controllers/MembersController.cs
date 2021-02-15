using Microsoft.AspNetCore.Mvc;
using Kutuphane.Business.Abstract;
using Kutuphane.Entities.Concrete;

namespace Kutuphane.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }


        [HttpGet]
        [Route("[action]")]
        public IActionResult Get()
        {
            var result = _memberService.GetList();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult Get(int id)
        {
            var result = _memberService.GetById(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Add(Member member)
        {
            var result = _memberService.Add(member);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult Update(Member member)
        {
            var result = _memberService.Update(member);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(Member member)
        {
            var result = _memberService.Delete(member);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
