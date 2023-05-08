using Microsoft.AspNetCore.Mvc;
using Ostral.Core.Interfaces;
using Ostral.Core.ViewModel;

namespace Ostral.WEB.Controllers;

[Route("dashboard")]
public class DashboardController: Controller
{
    private readonly ICourseService _courseService;
    private readonly ICategoryService _categoryService;

    public DashboardController(ICourseService courseService, ICategoryService categoryService)
    {
        _courseService = courseService;
        _categoryService = categoryService;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var courses = await _courseService.GetAllCourses();
        var categories = await _categoryService.GetAllCategories();
        var popularCourses = courses.Data.PageItems.Take(8);
        var recommendedCourses = courses.Data.PageItems.Take(4);
        
        var viewModel = new DashboardVM
        {
            Categories = categories,
            PopularCourses = popularCourses,
            RecommendedCourses = recommendedCourses
        };
        
        return View(viewModel);
    }
}
