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
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> ProductsAsync()
    {
        var itemsOnPage = await _productContext.Products
            .OrderByDescending(product => product.Priority).ThenBy(product => product.Name)
            .ToListAsync();

        return Ok(itemsOnPage);
    }

    [HttpPut]
    [Route("updateviewcount/{productId}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> LinkClickedAsync(int productId, [FromBody]Product product)
    {
        if (productId != product.ProductId)
            return BadRequest();

        _productContext.Entry(product).State = EntityState.Modified;

        await _productContext.SaveChangesAsync();

        return NoContent();
    }
}