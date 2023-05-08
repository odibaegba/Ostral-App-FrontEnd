using Ostral.Core.Responses;

namespace Ostral.Core.ViewModel
{
    public class HomeViewModel
    {
        public ResponseVM<IEnumerable<CourseListItem>> PopularCourses { get; set; }
        public ResponseVM<IEnumerable<TutorListItem>> Tutors { get; set; }
        public ResponseVM<IEnumerable<CategoryListItem>> Categories { get; set; }
    }
}
