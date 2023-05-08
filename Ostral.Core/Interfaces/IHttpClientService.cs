namespace Ostral.Core.Interfaces
{
    public interface IHttpClientService
    {
        Task<TRes> PostRequestAsync<TReq, TRes>(string baseUrl,
                                                string requestUrl,
                                                TReq requestModel)
            where TRes : class
            where TReq : class;

        Task<TRes> GetRequestAsync<TRes>(string baseUrl,
                                         string requestUrl)
            where TRes : class;
    }
}