using Ostral.Core.Responses;
using Ostral.Core.ViewModel;
using Ostral.Domain.Models;

namespace Ostral.Core.Interfaces
{
	public interface ICourseService
	{
		Task<ResponseVM<PaginatorResponseVM<IEnumerable<CourseListItem>>>> GetAllCourses();
		Task<ResponseVM<CourseResponse>> GetCourseById(string courseID);
	}
}