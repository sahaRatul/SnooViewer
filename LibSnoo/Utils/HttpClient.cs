using Newtonsoft.Json.Linq;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using net = System.Net.Http;

namespace LibSnoo.Utils
{
    public class HttpClient
    {
        private readonly net.HttpClient _client;

        public HttpClient(string userAgent = "TestUserAgent")
        {
            _client = new net.HttpClient();
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("User-Agent", userAgent);
        }

        public Task<Response> PostAsync<Request, Response>(string url, Request input, string token = null)
        {
            return CreateRequest<Response>(url, net.HttpMethod.Post, input, token);
        }

        public Task<Response> PutAsync<Request, Response>(string url, Request input, string token = null)
        {
            return CreateRequest<Response>(url, net.HttpMethod.Put, input, token);
        }

        public Task<Response> GetAsync<Response>(string url, string token = null)
        {
            return CreateRequest<Response>(url, net.HttpMethod.Get, token);
        }

        public Task<Response> DeleteAsync<Response>(string url, string token = null)
        {
            return CreateRequest<Response>(url, net.HttpMethod.Delete, token);
        }

        #region [ -- Private helper methods -- ]
        private Task<Response> CreateRequest<Response>(string url, net.HttpMethod method, string token)
        {
            return CreateRequestMessage(url, method, token, async (msg) =>
            {
                return await GetResult<Response>(msg);
            });
        }

        private Task<Response> CreateRequest<Response>(string url, net.HttpMethod method, object input, string token)
        {
            return CreateRequestMessage(url, method, token, async (msg) =>
            {
                using (var content = new net.StringContent(JObject.FromObject(input).ToString()))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    msg.Content = content;
                    return await GetResult<Response>(msg);

                }
            });
        }

        private async Task<Response> CreateRequestMessage<Response>(string url, net.HttpMethod method, string token, Func<net.HttpRequestMessage, Task<Response>> functor)
        {
            using (var msg = new net.HttpRequestMessage())
            {
                msg.RequestUri = new Uri(url);
                msg.Method = method;
                if (token != null)
                    msg.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                return await functor(msg);
            }
        }

        private async Task<Response> GetResult<Response>(net.HttpRequestMessage msg)
        {
            using (var response = await _client.SendAsync(msg))
            {
                using (var content = response.Content)
                {
                    var responseContent = await content.ReadAsStringAsync();
                    if (!response.IsSuccessStatusCode)
                        throw new Exception(responseContent);

                    if (typeof(IConvertible).IsAssignableFrom(typeof(Response)))
                        return (Response)Convert.ChangeType(responseContent, typeof(Response));
                    return JToken.Parse(responseContent).ToObject<Response>();
                }
            }
        }
        #endregion
    }
}
