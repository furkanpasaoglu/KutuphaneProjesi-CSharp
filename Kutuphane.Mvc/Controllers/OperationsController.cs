using Kutuphane.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Kutuphane.Mvc.Controllers
{
    public class OperationsController : Controller
    {
        private readonly IOperationService _operationService;

        public OperationsController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        public IActionResult Index(string p, int page = 1)
        {
            return View(_operationService.GetAll(p).Data.ToPagedList(page, 3));
        }
    }
}
