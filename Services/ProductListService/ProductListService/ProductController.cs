using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using ProductListService.Entities;

namespace ProductListService;

public class ProductController : ControllerBase
{
    private readonly ProductContext _productContext;

    public ProductController(ProductContext context)
    {
        _productContext = context ?? throw new ArgumentNullException(nameof(context));
    }

    [HttpGet]
    [Route("productlist")]
    [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> ProductsAsync()
    {

        int i = 0;
        var itemsOnPage = await _productContext.Products
            .OrderByDescending(product => product.Priority).ThenBy(product => product.Name)
            .ToListAsync();

        return Ok(itemsOnPage);
    }
}