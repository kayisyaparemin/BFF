using BFF.API.Models.DTOs.Product;
using BFF.Models.Entities;
using BFF.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Newtonsoft.Json;
using System.Net;

[ApiController]
[Route("api/[controller]")]
public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product =  await _productService.GetByIdAsync(id);

        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
    [HttpGet("all")]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productService.GetAllAsync();

        return Ok(products);
    }
    [HttpGet("list")]
    public async Task<IActionResult> GetProducts([FromBody] List<int> ids)
    {
        if (ids == null || ids.Count == 0)
        {
            return BadRequest();
        }

        var products = await _productService.GetByIdsAsync(ids);

        return Ok(products);
    }
    [HttpGet]
    [EnableQuery]
    [Route("filteredProducts/odata/")]
    public async Task<IActionResult> GetFilteredProducts(ODataQueryOptions<Product> options)
    {
        var products =  await _productService.GetFilteredAsync(options);

        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> InsertProduct([FromBody] ProductInsertDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _productService.InsertAsync<ProductInsertDto>(request);

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct([FromBody] ProductUpdateDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _productService.InsertAsync<ProductUpdateDto>(request);

        return StatusCode((int)HttpStatusCode.NoContent);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var existingProduct = await _productService.GetByIdAsync(id);

        if (existingProduct == null)
        {
            return NotFound();
        }

        await _productService.DeleteAsync(id);
        
        return StatusCode((int)HttpStatusCode.NoContent);
    }  
}

