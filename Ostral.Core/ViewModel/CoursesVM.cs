using Ostral.Core.Responses;
using Ostral.Core.Services;

namespace Ostral.Core.ViewModel;

public class CoursesVM
{
    public ResponseVM<PaginatorResponseVM<IEnumerable<CourseListItem>>> Courses { get; set; }
    public IEnumerable<CategoryDto> Categories { get; set; }
    public string? CategoryName { get; set; }
    public string CategoryImageUrl { get; set; }
}