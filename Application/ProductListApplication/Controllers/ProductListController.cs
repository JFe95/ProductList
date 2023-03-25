using Microsoft.AspNetCore.Mvc;
using ProductListApplication.Models;
using ProductListApplication.Services;
using System.Diagnostics;

namespace ProductListApplication.Controllers
{
    public class ProductListController : Controller
    {
        private readonly ILogger<ProductListController> _logger;
        private ProductListViewModel _viewModel;

        public ProductListController(ILogger<ProductListController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string sortOrder = "Default")
        {
            _viewModel = new ProductListViewModel { Products = ProductService.GetProductsAsync().GetAwaiter().GetResult() };
            _viewModel.Products = sortOrder switch
            {
                "Price" => _viewModel.Products.OrderBy(product => product.Price).ToList(),
                "ViewCount" => _viewModel.Products.OrderByDescending(product => product.ViewCount).ToList(),
                "Default" => _viewModel.Products.OrderByDescending(product => product.Priority).ThenBy(product => product.Name).ToList(),
                _ => throw new ArgumentException(nameof(sortOrder), sortOrder, null)
            };
            _viewModel.SelectedItem = sortOrder;

            return View(_viewModel);
        }

        public IActionResult LinkClicked(int productId)
        {
            _viewModel = new ProductListViewModel { Products = ProductService.GetProductsAsync().GetAwaiter().GetResult() };
            var product = _viewModel.Products.First(p => p.ProductId == productId);

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