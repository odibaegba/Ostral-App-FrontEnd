using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Ostral.ConfigOptions;
using Ostral.Core.Constants;
using Ostral.Core.Interfaces;
using Ostral.Core.Responses;
using Ostral.Core.ViewModel;
using Ostral.Domain.Models;

namespace Ostral.Core.Services
{
	public class CourseService : ICourseService
	{
		private readonly IHttpClientService _httpClientService;
		private readonly string _baseUrl;

		public CourseService(IHttpClientService httpClientService, ApiSettings apiSettings)
        {
            _httpClientService = httpClientService;
            _baseUrl = apiSettings.BaseUrl!;
        }

        public async Task<ResponseVM<PaginatorResponseVM<IEnumerable<CourseListItem>>>> GetAllCourses()
		{
			var result = await _httpClientService.GetRequestAsync<ResponseVM<PaginatorResponseVM<IEnumerable<CourseListItem>>>>(_baseUrl, ApiRoutes.Course.GetAllCourses);
			
			return result;
		}

		public async Task<ResponseVM<CourseResponse>> GetCourseById(string courseId)
		{
			var result = await _httpClientService.GetRequestAsync<ResponseVM<CourseResponse>>(_baseUrl, ApiRoutes.Course.GetCourseById(courseId));

			return result;
		}
	}
}
