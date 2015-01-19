using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OpenAuth.Http;

namespace OpenAuth
{
    public class OpenAuthClient : IOpenAuthClient
    {
        protected HttpClient apiInvoker;

        public OpenAuthClient()
        {

        }

        public Task<ApiResponseMessage> ExecuteAsync(ApiRequestMessage request)
        {
            return apiInvoker.SendAsync(request).ContinueWith<ApiResponseMessage>((Task<HttpResponseMessage> task) =>
            {
                return (ApiResponseMessage)task.Result;
            });
        }

        public Task<ApiResponseMessage<T>> ExecuteAsync<T>(ApiRequestMessage request)
        {
            return null;
        }

        public ApiResponseMessage Execute(ApiRequestMessage request)
        {
            return (ApiResponseMessage)apiInvoker.Send(request);
        }

        public ApiResponseMessage<T> Execute<T>(ApiRequestMessage request)
        {
            return null;
        }

        public void Dispose()
        {
            apiInvoker.Dispose();
        }
    }
}
