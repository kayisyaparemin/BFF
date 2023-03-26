using BFF.Models.Entities;
using BFF.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Net;

[ApiController]
[Route("odata/[controller]")]
public class ProductController : ODataController
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("{id}")]
    [EnableQuery]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product =  await _productService.GetProductAsync(id);

        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpGet]
    [EnableQuery]
    public async Task<IActionResult> GetAllProducts(ODataQueryOptions<Product> options)
    {
        var products =  await _productService.GetAllProductsAsync(options);

        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> InsertProduct([FromBody] Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _productService.InsertAsync(product);

        return Created(product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct([FromBody] Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _productService.UpdateAsync(product);

        return StatusCode((int)HttpStatusCode.NoContent);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var existingProduct = await _productService.GetProductAsync(id);

        if (existingProduct == null)
        {
            return NotFound();
        }

        await _productService.DeleteAsync(id);
        
        return StatusCode((int)HttpStatusCode.NoContent);
    }

    [HttpPost("list")]
    public async Task<IActionResult> GetProducts([FromBody] List<int> ids)
    {
        if (ids == null || ids.Count == 0)
        {
            return BadRequest();
        }

        var products = await _productService.GetProductsAsync(ids);

        return Ok(products);
    }
}

