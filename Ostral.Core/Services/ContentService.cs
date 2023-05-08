using Microsoft.Extensions.Configuration;
using Ostral.ConfigOptions;
using Ostral.Core.Constants;
using Ostral.Core.Interfaces;
using Ostral.Core.Responses;
using Ostral.Core.ViewModel;

namespace Ostral.Core.Services
{
    public class ContentService : IContentService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly string _baseUrl;

        public ContentService(IHttpClientService httpClientService, ApiSettings apiSettings)
        {
            _httpClientService = httpClientService;
            _baseUrl = apiSettings.BaseUrl!;
        }

        public async Task<ResponseVM<ContentDetailedResponse>> GetContentById(string contentId)
        {
            var result = await _httpClientService.GetRequestAsync<ResponseVM<ContentDetailedResponse>>(_baseUrl, ApiRoutes.Content.GetContentById(contentId));

            return result;
        }
    }
}
