using BFF.Models.Entities;
using BFF.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Net;

[ApiController]
[Route("odata/[controller]")]
public class CategoryController : ODataController
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("{id}")]
    [EnableQuery]
    public async Task<IActionResult> GetCategory(int id)
    {
        var product = await _categoryService.GetCategoryAsync(id);

        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpGet]
    [EnableQuery]
    public async Task<IActionResult> GetAllCategories(ODataQueryOptions<Category> options)
    {
        var categories = await _categoryService.GetAllCategoriesAsync(options);

       return Ok(categories);
    }

    [HttpPost]
    public async Task<IActionResult> InsertCategory([FromBody] Category category)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _categoryService.InsertAsync(category);

        return Created(category);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory([FromBody] Category category)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _categoryService.UpdateAsync(category);

        return StatusCode((int)HttpStatusCode.NoContent);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var existingProduct = await _categoryService.GetCategoryAsync(id);

        if (existingProduct == null)
        {
            return NotFound();
        }

        await _categoryService.DeleteAsync(id);

        return StatusCode((int)HttpStatusCode.NoContent);
    }

    [HttpPost("list")]
    public async Task<IActionResult> GetCategories([FromBody] List<int> ids)
    {
        if (ids == null || ids.Count == 0)
        {
            return BadRequest();
        }

        var categories = await _categoryService.GetCategoriesAsync(ids);

        return Ok(categories);
    }
}

