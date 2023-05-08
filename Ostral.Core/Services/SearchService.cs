using Microsoft.Extensions.Configuration;
using Ostral.ConfigOptions;
using Ostral.Core.Constants;
using Ostral.Core.Interfaces;
using Ostral.Core.Responses;
using Ostral.Core.ViewModel;

namespace Ostral.Core.Services;

public class SearchService: ISearchService
{
    private readonly IHttpClientService _httpClientService;
    private readonly string _baseUrl;

    public SearchService(IHttpClientService httpClientService, ApiSettings apiSettings)
    {
        _httpClientService = httpClientService;
        _baseUrl = apiSettings.BaseUrl!;
    }
    
    public async Task<ResponseVM<PaginatorResponseVM<IEnumerable<CourseListItem>>>> SearchCourse(string keyword)
    {
        var response =
            await _httpClientService.GetRequestAsync<ResponseVM<PaginatorResponseVM<IEnumerable<CourseListItem>>>>(
                _baseUrl, ApiRoutes.Search.SearchByKeyword(keyword));

        return response;
    }
}