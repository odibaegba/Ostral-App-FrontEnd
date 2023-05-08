using Ostral.Core.Responses;
using Ostral.Core.ViewModel;

namespace Ostral.Core.Interfaces;

public interface ISearchService
{
    Task<ResponseVM<PaginatorResponseVM<IEnumerable<CourseListItem>>>> SearchCourse(string keyword);
}