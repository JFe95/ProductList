using Microsoft.AspNetCore.Mvc;
using ProductListApplication.Models;
using ProductListApplication.Services;
using System.Diagnostics;
using ProductListService.Entities;

namespace ProductListApplication.Controllers
{
    public class ProductListController : Controller
    {
        private readonly ILogger<ProductListController> _logger;
        private ProductListViewModel viewModel = new() { Products = ProductService.GetProductsAsync().GetAwaiter().GetResult() };

        public ProductListController(ILogger<ProductListController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(viewModel);
        }

        public IActionResult LinkClicked(int productId)
        {
            var product = viewModel.Products.First(p => p.ProductId == productId);

            if (string.IsNullOrEmpty(product.Url))
                return new EmptyResult();

            product.ViewCount++;
            try
            {
                ProductService.ProductClickedAsync(product).GetAwaiter().GetResult();
            }
            catch(Exception e){_logger.Log(LogLevel.Error, e, $"Failed to update View Count for Product {productId}: {product.Name}");}

            return Redirect(product.Url);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}