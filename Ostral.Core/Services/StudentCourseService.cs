using Ostral.Core.Constants;
using Ostral.Core.Interfaces;
using Ostral.Core.Responses;
using Ostral.Core.ViewModel;
using Ostral.ConfigOptions;

namespace Ostral.Core.Services
{
    public class StudentCourseService: IStudentCourseService
    {
        private readonly IHttpClientService _httpClientService;
        private string _baseUrl;

        public StudentCourseService(IHttpClientService httpClientService, ApiSettings apiSettings)
        {
            _httpClientService = httpClientService;
            _baseUrl = apiSettings.BaseUrl!;
        }

        public async Task<ResponseVM<PaginatorResponseVM<IEnumerable<StudentCourseResponse>>>> GetAllStudentCourses(string studentId)
        {
            var result = await _httpClientService.GetRequestAsync<ResponseVM<PaginatorResponseVM<IEnumerable<StudentCourseResponse>>>>(_baseUrl, ApiRoutes.StudentCourse.GetStudentCourses(studentId));

            return result;
        }

        public async Task<ResponseVM<CourseResponse>> EnrollForCourse(string courseID, string studentID)
        {
            var result = await _httpClientService.PostRequestAsync<object, ResponseVM<CourseResponse>>(_baseUrl, ApiRoutes.Course.EnrollForACourse(courseID, studentID), null);

            return result;
        }
    }
}
