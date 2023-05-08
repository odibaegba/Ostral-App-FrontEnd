using Microsoft.AspNetCore.Mvc;
using Ostral.Core.Interfaces;
using Ostral.Core.ViewModel;

namespace Ostral.WEB.Controllers;

[Route("search")]
public class SearchController: Controller
{
    private readonly ISearchService _searchService;
    private readonly ICategoryService _categoryService;

    public SearchController(ISearchService searchService, ICategoryService categoryService)
    {
        _searchService = searchService;
        _categoryService = categoryService;
    }

    [HttpGet("")]
    public async Task<IActionResult> SearchByKeyword(string keyword)
    {
        var courses = await _searchService.SearchCourse(keyword);
        var categories = await _categoryService.GetAllCategories();

        var viewModel = new CoursesVM
        {
            Courses = courses,
            Categories = categories,
            CategoryName = $"Search result for \"{keyword}\""
        };

        return View("Index", viewModel);
    }
}