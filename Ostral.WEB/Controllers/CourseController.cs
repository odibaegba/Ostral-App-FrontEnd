using Microsoft.AspNetCore.Mvc;
using Ostral.Core.Interfaces;
using System.Security.Claims;
using Ostral.Core.ViewModel;

namespace Ostral.WEB.Controllers
{
	[Route("course")]
    public class CourseController : Controller
    {
	    private readonly ICategoryCoursesService _categoryCoursesService;
	    private readonly ILogger<CourseController> _logger;
		private readonly ICourseService _courseService;
		private readonly IStudentCourseService _studentCourseService;
		private readonly ICategoryService _categoryService;

		public CourseController(ILogger<CourseController> logger, ICourseService courseService, IStudentCourseService studentCourseService, ICategoryService categoryService, ICategoryCoursesService categoryCoursesService)
		{
			_categoryCoursesService = categoryCoursesService;
			_courseService = courseService;
			_studentCourseService = studentCourseService;
			_categoryService = categoryService;
			_logger = logger;
        }

		public async Task<ActionResult> Index()
		{
			var courses = await _courseService.GetAllCourses();
			var categories = await _categoryService.GetAllCategories();

			var viewModel = new CoursesVM
			{
				Courses = courses,
				Categories = categories,
			};
			return courses.Data == null || !courses.Data.PageItems.Any() ? NotFound() : View(viewModel);
		}
		
		[Route("{id}")]
		public async Task<ActionResult> Details([FromRoute] string id)
		{
			var claim = HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
			ViewBag.UserId = (claim != null ? claim.Value : null) ?? string.Empty;
			var result = await _courseService.GetCourseById(id);
			
			if (result == null)
				return NotFound();
			
			// check if student is already registered
			if (!string.IsNullOrWhiteSpace(ViewBag.UserId))
			{
				var studentCourses = await _studentCourseService.GetAllStudentCourses((string)ViewBag.UserId);
				if (studentCourses?.Data?.PageItems?.Where(sc => sc.CourseId == id).FirstOrDefault() != null)
					result.Data.IsRegistered = true;
			}

			var relatedCourses = await _categoryCoursesService.GetCoursesByCategory(result.Data.CategoryId);
			
			var viewModel = new CourseDetailsVM
			{
				Course = result.Data,
				RelatedCourses = relatedCourses.Data.PageItems.Take(4)
			};
			
			return View(viewModel);
		}
	}
}