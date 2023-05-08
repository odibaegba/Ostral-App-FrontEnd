using Microsoft.AspNetCore.Mvc;
using Ostral.Core.Interfaces;
using Ostral.Core.Services;
using Ostral.Core.ViewModel;
using System.Security.Claims;

namespace Ostral.WEB.Controllers
{
    [Route("course/{courseId}/content")]
    public class ContentController : Controller
    {
        private readonly IContentService _contentService;
        private readonly ICourseService _courseService;

        public ContentController(IContentService contentService, ICourseService courseService)
        {
            _contentService = contentService;
            _courseService = courseService;
        }

        [HttpGet("{contentId}")]
        public async Task<IActionResult> ShowContent([FromRoute] string courseId, [FromRoute] string contentId)
        {
            var claim = HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            ViewBag.UserId = (claim != null ? claim.Value : null) ?? string.Empty;
            var contentResponse = await _contentService.GetContentById(contentId);
            var courseResponse = await _courseService.GetCourseById(courseId);

            ShowContentVM showContentVM = new ShowContentVM
            {
                Content = contentResponse.Data,
                Course = courseResponse.Data
            };
            return View(showContentVM);
        }
    }
}
