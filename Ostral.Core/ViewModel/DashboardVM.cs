using Ostral.Core.Responses;
using Ostral.Core.Services;

namespace Ostral.Core.ViewModel;

public class DashboardVM
{
    public IEnumerable<CategoryDto> Categories { get; set; }
    public IEnumerable<CourseListItem> RecommendedCourses { get; set; }
    public IEnumerable<CourseListItem> PopularCourses { get; set; }
}