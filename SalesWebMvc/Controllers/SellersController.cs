using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _seellerService;

        public SellersController(SellerService seellerService)
        {
            _seellerService = seellerService;
        }
        public IActionResult Index()
        {
            var list = _seellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
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
