using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _seellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService seellerService, DepartmentService departmentService)
        {
            _seellerService = seellerService;
            _departmentService = departmentService;
        }

        
        public IActionResult Index()
        {
            var list = _seellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _seellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
