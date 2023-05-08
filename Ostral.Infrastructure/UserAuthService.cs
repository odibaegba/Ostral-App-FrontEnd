using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Ostral.Core.Interfaces;
using Ostral.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ostral.Infrastructure
{
    public class UserAuthService : IUserAuthService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IConfiguration _configuration;
        public UserAuthService(IHttpClientService httpClientService, IConfiguration configuration)
        {
            _httpClientService = httpClientService;
            _configuration = configuration;
              
        }
        // public async Task<ChallengeResult> ExternalLogin()
        // {
        //     var baseUrl = _configuration.GetValue<string>("MyApiSettings:BaseUrl");
        //     var url = baseUrl + "/User";
        //     var token = string.Empty;
        //     string s = string.Empty;
        //     var result = await _httpClientService.PostRequestAsync<string, ChallengeResult>(baseUrl, url, s, token);
        //     return result;
        // }
        //
        // public async Task<LoginVM> Login()
        // {
        //     var baseUrl = _configuration.GetValue<string>("MyApiSettings:BaseUrl");
        //     var url = baseUrl + "/User";
        //     var token = string.Empty;
        //     var result= await _httpClientService.GetRequestAsync<LoginVM>(baseUrl, url, token);
        //     return result;
        // }
        public Task<LoginVM> Login()
        {
            throw new NotImplementedException();
        }

        public Task<ChallengeResult> ExternalLogin()
        {
            throw new NotImplementedException();
        }
    }
}
