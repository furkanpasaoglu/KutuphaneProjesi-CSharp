using Microsoft.AspNetCore.Mvc;
using Kutuphane.Business.Abstract;
using Kutuphane.Entities.Concrete;
using X.PagedList;

namespace Kutuphane.MVC.Controllers
{
    public class MembersController : Controller
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public IActionResult Index(string p, int page = 1)
        {
            return View(_memberService.GetList(p).Data.ToPagedList(page, 3));
        }

        [HttpGet]
        public IActionResult AddMember()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMember(Member member)
        {
            if (!ModelState.IsValid)
            {
                return View("AddMember");
            }
            _memberService.Add(member);
            TempData["Mesaj"] = member.Name + " Üye Eklendi!";
            return RedirectToAction("Index");
        }

        public IActionResult DeleteMember(int id)
        {
            var query = _memberService.GetById(id).Data;
            _memberService.Delete(query);
            TempData["Mesaj"] = query.Name + " Üye Silindi!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateMember(int id)
        {
            var query = _memberService.GetById(id).Data;
            return View("UpdateMember", query);
        }

        [HttpPost]
        public IActionResult UpdateMember(Member member)
        {
            _memberService.Update(member);
            TempData["Mesaj"] = member.Name + " Üye Bilgileri Güncellendi!";
            return RedirectToAction("Index");
        }
    }
}
