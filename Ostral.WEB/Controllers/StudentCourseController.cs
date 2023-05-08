using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Ostral.Core.Interfaces;

namespace Ostral.WEB.Controllers
{
    public class StudentCourseController : Controller
    {
        private readonly ILogger<StudentCourseController> _logger;
        private readonly IStudentCourseService _studentCourseService;

        public StudentCourseController(ILogger<StudentCourseController> logger, IStudentCourseService studentCourseService)
        {
            _studentCourseService = studentCourseService;
            _logger = logger;
        }

        public async Task<ActionResult> Index(string id)
        {
            var result = await _studentCourseService.GetAllStudentCourses(id);
            return result.Data == null ? NotFound() : View(result.Data.PageItems);
        }

        //public async Task<ActionResult> Details(string id)
        //{
        //    var result = await _studentCourseService.GetAllStudentCourses(id);
        //    return result == null ? NotFound() : View(result.Data);
        //}

        [HttpGet("enroll")]
        public async Task<ActionResult> EnrollForACourse(string courseID, string studentID)
        {
            if (!HttpContext.User.Claims.Any())
            {
                return RedirectToRoute(new {action = "Login", controller = "Auth"});
            }
            
            ViewBag.UserId = HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var result = await _studentCourseService.EnrollForCourse(courseID, studentID);
            return result == null ? NotFound() : RedirectToRoute(new { action = "Details", controller = "Course", id = courseID});
        }
    }
}

