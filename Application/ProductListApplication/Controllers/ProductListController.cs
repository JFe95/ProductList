using Microsoft.AspNetCore.Mvc;
using ProductListApplication.Models;
using ProductListApplication.Services;
using System.Diagnostics;

namespace ProductListApplication.Controllers
{
    public class ProductListController : Controller
    {
        private readonly ILogger<ProductListController> _logger;

        public ProductListController(ILogger<ProductListController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new ProductListViewModel{Products = ProductService.GetProductsAsync().GetAwaiter().GetResult()});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}