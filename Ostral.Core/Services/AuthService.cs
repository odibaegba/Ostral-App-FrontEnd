using AutoMapper;
using Microsoft.Extensions.Configuration;
using Ostral.ConfigOptions;
using Ostral.Core.Interfaces;
using Ostral.Core.ViewModel;
using Ostral.Core.Constants;
using Ostral.Core.Requests;
using Ostral.Core.Responses;

namespace Ostral.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientService _httpClient;
        private readonly IMapper _mapper;
        private readonly string _baseUrl;

        public AuthService(IHttpClientService httpClient, IMapper mapper, ApiSettings apiSettings)
        {
            _httpClient = httpClient;
            _mapper = mapper;
            _baseUrl = apiSettings.BaseUrl!;
        }

        public async Task<ResponseVM<AuthResponse>> Login(LoginVM model)
        {
            var loginRequest = _mapper.Map<LoginRequest>(model);

            var response =
                await _httpClient.PostRequestAsync<LoginRequest, ResponseVM<AuthResponse>>(_baseUrl,
                    ApiRoutes.Auth.Login, loginRequest);

            return response;
        }

        public async Task<ResponseVM<AuthResponse>> Register(RegisterVM model)
        {
            var registerRequest = _mapper.Map<RegisterRequest>(model);
            
            var response =
                await _httpClient.PostRequestAsync<RegisterRequest, ResponseVM<AuthResponse>>(_baseUrl,
                    ApiRoutes.Auth.RegisterStudentRoute, registerRequest);

            return response;
        }
    }
}