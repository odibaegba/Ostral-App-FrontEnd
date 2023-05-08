using Ostral.Core.Responses;
using Ostral.Core.ViewModel;

namespace Ostral.Core.Interfaces
{
    public interface IHomeService
    {
        Task<ResponseVM<IEnumerable<CourseListItem>>> GetPopularCourses();
        Task<ResponseVM<IEnumerable<TutorListItem>>> GetPopularTutors();
        Task<ResponseVM<IEnumerable<CategoryListItem>>> GetCategories();
    }
}
