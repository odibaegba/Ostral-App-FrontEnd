using Microsoft.AspNetCore.Mvc;
using Ostral.Core.Interfaces;
using Ostral.Core.ViewModel;

namespace Ostral.WEB.Controllers;

[Route("category")]
public class CategoryCourseController: Controller
{
    private readonly ICategoryService _categoryService;
    private readonly ICategoryCoursesService _categoryCoursesService;

    public CategoryCourseController(ICategoryService categoryService, ICategoryCoursesService categoryCoursesService)
    {
        _categoryService = categoryService;
        _categoryCoursesService = categoryCoursesService;
    }

    [HttpGet("{categoryId}/course")]
    public async Task<IActionResult> ShowCategoryCourses([FromRoute] string categoryId)
    {
        var courses = await _categoryCoursesService.GetCoursesByCategory(categoryId);
        var categories = await _categoryService.GetAllCategories();
        var category = await _categoryService.GetCategoryById(categoryId);

        var viewModel = new CoursesVM
        {
            Courses = courses,
            Categories = categories,
            CategoryName = category.Name,
            CategoryImageUrl = category.ImageUrl,
        };
        
        return View(viewModel);
    }
}