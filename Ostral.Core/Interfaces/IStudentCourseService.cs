using Ostral.Core.Responses;
using Ostral.Core.ViewModel;

namespace Ostral.Core.Interfaces
{
    public interface IStudentCourseService
    {
        Task<ResponseVM<PaginatorResponseVM<IEnumerable<StudentCourseResponse>>>> GetAllStudentCourses(string studentId);
        Task<ResponseVM<CourseResponse>> EnrollForCourse(string courseID, string studentID);
    }
}
