using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;

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
    }
}
