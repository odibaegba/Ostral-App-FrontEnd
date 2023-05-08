using Ostral.Core.Responses;
using Ostral.Core.ViewModel;

namespace Ostral.Core.Interfaces;

public interface ICategoryCoursesService
{
    Task<ResponseVM<PaginatorResponseVM<IEnumerable<CourseListItem>>>> GetCoursesByCategory(string categoryId);
}