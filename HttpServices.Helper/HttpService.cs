using Newtonsoft.Json;
using System.Text;

namespace HttpServices.Helper
{
    public class HttpService : IHttpService
    {
        public async Task<HttpResponseMessage> HttpPostRequest(string url, object data)
        {
            var requestResponse = await HttpPostRequest(url, data, Encoding.UTF8, "application/json");
            var dasta = await requestResponse.Content.ReadAsStringAsync();
            return requestResponse;
        }

        public async Task<HttpResponseMessage> HttpPostRequest(string url, object data, Encoding encodingType, string contentType)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var myContent = JsonConvert.SerializeObject(data);
                var content = new StringContent(myContent, encodingType, contentType);
                var requestResponse = await httpClient.PostAsync(url, content);
                return requestResponse;
            }
        }

    }
}