using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kutuphane.Business.Abstract;
using Kutuphane.Entities.Concrete;
using Kutuphane.MVC.Models.ListView;
using X.PagedList;


namespace Kutuphane.MVC.Controllers
{
    public class MembersController : Controller
    {
        private IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public IActionResult Index(string p, int page = 1)
        {
            if (!String.IsNullOrEmpty(p) && page > 0)
            {
                return View(_memberService.GetList(page, 3, x => x.Name.Contains(p)));
            }
            else
            {
                return View(_memberService.GetList(page, 3));
            }
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
            return View();
        }

        public IActionResult DeleteMember(int id)
        {
            var query = _memberService.GetById(id);
            _memberService.Delete(query);
            TempData["Mesaj"] = query.Name + " Üye Silindi!";
            return RedirectToAction("Index", "Members");
        }

        [HttpGet]
        public IActionResult UpdateMember(int id)
        {
            var query = _memberService.GetById(id);
            return View("UpdateMember", query);
        }

        [HttpPost]
        public IActionResult UpdateMember(Member member)
        {
            _memberService.Update(member);
            TempData["Mesaj"] = member.Name + " Üye Bilgileri Güncellendi!";
            return View();
        }
    }
}
