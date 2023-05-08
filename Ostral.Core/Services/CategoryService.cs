using Microsoft.Extensions.Configuration;
using Ostral.ConfigOptions;
using Ostral.Core.Constants;
using Ostral.Core.Interfaces;
using Ostral.Core.ViewModel;

namespace Ostral.Core.Services;

public class CategoryService: ICategoryService
{
    private readonly IHttpClientService _httpClient;
    private readonly string _baseUrl;

    public CategoryService(IHttpClientService httpClient, ApiSettings apiSettings)
    {
        _httpClient = httpClient;
        _baseUrl = apiSettings.BaseUrl!;
    }

    public async Task<CategoryDto> GetCategoryById(string categoryId)
    {
        var response =
            await _httpClient.GetRequestAsync<ResponseVM<CategoryDto>>(_baseUrl,
                ApiRoutes.Category.GetCategoryById(categoryId));

        return response.Data!;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategories()
    {
        var response =
            await _httpClient.GetRequestAsync<ResponseVM<IEnumerable<CategoryDto>>>(_baseUrl,
                ApiRoutes.Category.Categories);

        return response.Data!;
    }
}

public class CategoryDto
{
    public string Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}