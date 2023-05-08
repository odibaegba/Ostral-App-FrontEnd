using Newtonsoft.Json;
using System.Net;

namespace Ostral.Core.ViewModel
{
    public class ResponseVM<T>
    {
        public int StatusCode { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public IEnumerable<string> Errors { get; set; } = Array.Empty<string>();
        public T? Data { get; set; }

        public static ResponseVM<T> Fail(IEnumerable<string> errors, int statusCode = (int)HttpStatusCode.NotFound)
        {
            return new ResponseVM<T>
            {
                Status = false,
                Errors = errors,
                StatusCode = statusCode
            };
        }

        public static ResponseVM<T> Success(T data, string successMessage = "", int statusCode = (int)HttpStatusCode.OK)
        {
            return new ResponseVM<T>
            {
                Status = true,
                Message = successMessage,
                Data = data,
                StatusCode = statusCode
            };
        }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}