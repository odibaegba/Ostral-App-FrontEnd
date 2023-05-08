using Microsoft.Extensions.Configuration;
using Ostral.ConfigOptions;
using Ostral.Core.Constants;
using Ostral.Core.Interfaces;
using Ostral.Core.Responses;
using Ostral.Core.ViewModel;

namespace Ostral.Core.Services;

public class CategoryCoursesService: ICategoryCoursesService
{
    private readonly IHttpClientService _httpClient;
    private readonly string _baseUrl;

    public CategoryCoursesService(IHttpClientService httpClient, ApiSettings apiSettings)
    {
        _httpClient = httpClient;
        _baseUrl = apiSettings.BaseUrl!;
    }


    public async Task<ResponseVM<PaginatorResponseVM<IEnumerable<CourseListItem>>>> GetCoursesByCategory(string categoryId)
    {
        var result = await _httpClient.GetRequestAsync<ResponseVM<PaginatorResponseVM<IEnumerable<CourseListItem>>>>(_baseUrl, ApiRoutes.CategoryCourse.CategoryCoursesById(categoryId));
			
        return result;
    }
}