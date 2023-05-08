using Ostral.Core.Responses;

namespace Ostral.Core.ViewModel;

public class CourseDetailsVM
{
    public CourseResponse Course { get; set; }
    public IEnumerable<CourseListItem> RelatedCourses { get; set; }
}