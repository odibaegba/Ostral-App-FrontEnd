using Microsoft.AspNetCore.Mvc;
using Ostral.Core.Interfaces;
using Ostral.Core.Services;

namespace Ostral.WEB.Controllers;

[Route("category")]
public class CategoryController: Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    // public async Task<IActionResult> GetCategories()
    // {
    //     var result = await _categoryService.GetAllCategories();
    //
    //     return View(result);
    // }
}
