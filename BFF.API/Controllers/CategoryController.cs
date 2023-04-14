using BFF.API.Models.DTOs.Category;
using BFF.Models.Entities;
using BFF.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Net;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(int id)
    {
        var product = await _categoryService.GetByIdAsync(id);

        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
    [HttpPost("list")]
    public async Task<IActionResult> GetCategories([FromBody] List<int> ids)
    {
        if (ids == null || ids.Count == 0)
        {
            return BadRequest();
        }

        var categories = await _categoryService.GetByIdsAsync(ids);

        return Ok(categories);
    }
    [HttpGet("all")]
    public async Task<IActionResult> GetAllCategories()
    {
        var products = await _categoryService.GetAllAsync();

        return Ok(products);
    }

    [HttpGet]
    [EnableQuery]
    [Route("filteredCategories/odata/")]
    public async Task<IActionResult> GetFilteredCategories(ODataQueryOptions<Category> options)
    {
        var categories = await _categoryService.GetFilteredAsync(options);

       return Ok(categories);
    }

    [HttpPost]
    public async Task<IActionResult> InsertCategory([FromBody] CategoryInsertDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _categoryService.InsertAsync<CategoryInsertDto>(request);

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory([FromBody] CategoryUpdateDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _categoryService.UpdateAsync<CategoryUpdateDto>(request);

        return StatusCode((int)HttpStatusCode.NoContent);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var existingProduct = await _categoryService.GetByIdAsync(id);

        if (existingProduct == null)
        {
            return NotFound();
        }

        await _categoryService.DeleteAsync(id);

        return StatusCode((int)HttpStatusCode.NoContent);
    }

    
}

