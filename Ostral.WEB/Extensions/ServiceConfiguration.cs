using Ostral.Core.Interfaces;
using Ostral.Core.Services;
using Ostral.Infrastructure.ExternalServices;
using Ostral.Infrastructure;
using Ostral.WEB.Controllers;

namespace Ostral.WEB.Extensions
{
    public static class ServiceConfiguration
    {
        public static void AddServicesExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IHttpClientService, HttpClientService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IStudentCourseService, StudentCourseService>();
            services.AddScoped<IUserAuthService, UserAuthService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryCoursesService, CategoryCoursesService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IContentService, ContentService>();
            services.AddScoped<ICommentService, CommentService>();
        }
    }
}