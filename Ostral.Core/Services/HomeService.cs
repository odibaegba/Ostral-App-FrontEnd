using AutoMapper;
using Microsoft.Extensions.Configuration;
using Ostral.ConfigOptions;
using Ostral.Core.Constants;
using Ostral.Core.Interfaces;
using Ostral.Core.Responses;
using Ostral.Core.ViewModel;

namespace Ostral.Core.Services
{
    public class HomeService : IHomeService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly string _baseUrl;

        public HomeService(IHttpClientService httpClient, ApiSettings apiSettings)
        {
            _httpClientService = httpClient;
            _baseUrl = apiSettings.BaseUrl!;
        }

        public async Task<ResponseVM<IEnumerable<CourseListItem>>> GetPopularCourses()
        {

            var courseResponse = await _httpClientService.GetRequestAsync<ResponseVM<IEnumerable<CourseListItem>>>(_baseUrl!, ApiRoutes.Course.PopularCourses);

            return new ResponseVM<IEnumerable<CourseListItem>>
            {
                Data = courseResponse.Data,
                Status = courseResponse.Status,
                Errors = courseResponse.Errors,
                Message = courseResponse.Message,
                StatusCode = courseResponse.StatusCode,
            };
        }

        public async Task<ResponseVM<CourseListItem>> GetRandomCourses()
        {
            var courseResponse = await _httpClientService.GetRequestAsync<ResponseVM<CourseListItem>>(_baseUrl!, ApiRoutes.Course.RandomCourse);

            return courseResponse;

        }

        public async Task<ResponseVM<IEnumerable<TutorListItem>>> GetPopularTutors()
        {
            var response = await _httpClientService.GetRequestAsync<ResponseVM<IEnumerable<TutorListItem>>>(_baseUrl!, ApiRoutes.Tutor.PopularTutors);

            return new ResponseVM<IEnumerable<TutorListItem>>
            {
                Data =  response.Data!,
                Status = response.Status,
                Errors = response.Errors,
                Message = response.Message,
                StatusCode = response.StatusCode,
            };
        }

        public async Task<ResponseVM<IEnumerable<CategoryListItem>>> GetCategories()
        {
            var response = await _httpClientService.GetRequestAsync<ResponseVM<IEnumerable<CategoryListItem>>>(_baseUrl!, ApiRoutes.Category.Categories);
            
            return new ResponseVM<IEnumerable<CategoryListItem>>
            {
                Data = response.Data!,
                Status = response.Status,
                Errors = response.Errors,
                Message = response.Message,
                StatusCode = response.StatusCode,
            };
        }
        
        
    }
}
