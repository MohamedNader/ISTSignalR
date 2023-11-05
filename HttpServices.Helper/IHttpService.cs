using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpServices.Helper
{
    public interface IHttpService
    {
        Task<HttpResponseMessage> HttpPostRequest(string url, object data);

        Task<HttpResponseMessage> HttpPostRequest(string url, object data, Encoding encodingType, string contentType);
    }
}
