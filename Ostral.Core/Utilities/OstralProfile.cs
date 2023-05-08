using AutoMapper;
using Ostral.Core.Requests;
using Ostral.Core.ViewModel;
using Ostral.Domain.Models;

namespace Ostral.Core.Utilities
{
    public class OstralProfile : Profile
    {
        public OstralProfile()
        {
            CreateMap<LoginVM, LoginRequest>();
            CreateMap<RegisterVM, RegisterRequest>();
            CreateMap<Course, CourseRequest>();
        }
    }
}