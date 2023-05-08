using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Ostral.Core.Interfaces;

namespace Ostral.Infrastructure.ExternalServices
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpClientService(IHttpClientFactory clientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _clientFactory = clientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TRes> GetRequestAsync<TRes>(string baseUrl, string url)
            where TRes : class
        {
            var client = CreateClient(baseUrl);
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var result = await GetResponseResultAsync<TRes>(client, request);
            return result;
        }

        public async Task<TRes> PostRequestAsync<TReq, TRes>(string baseUrl, string url, TReq requestModel)
            where TRes : class
            where TReq : class
        {
            var client = CreateClient(baseUrl);
            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(JsonConvert.SerializeObject(requestModel), null, "application/json")
            };
            return await GetResponseResultAsync<TRes>(client, request);
        }

        private static async Task<TRes> GetResponseResultAsync<TRes>(HttpClient client, HttpRequestMessage request)
            where TRes : class
        {
            var response = await client.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();


            var result = JsonConvert.DeserializeObject<TRes>(responseString);
            return result!;
        }

        private HttpClient CreateClient(string baseUrl)
        {
          
            var token = "";
            if (_httpContextAccessor.HttpContext?.User?.Claims != null)
                token = (_httpContextAccessor.HttpContext?.User?.Claims)!.FirstOrDefault(c => c.Type == "jwt")?.Value;
            
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(baseUrl);
            if (!string.IsNullOrEmpty(token))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return client;
        }
    }
}