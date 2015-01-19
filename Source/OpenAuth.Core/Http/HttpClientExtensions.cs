using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenAuth.Http
{
    public static class HttpClientExtensions
    {
        public static string GetString(this HttpClient httpClient, string requestUri)
        {
            return GetString(httpClient, CreateUri(requestUri));
        }

        public static string GetString(this HttpClient httpClient, Uri requestUri)
        {
            if (httpClient == null)
            {
                throw new ArgumentNullException("httpClient");
            }
            return AsyncHelper.RunSync<string>(() => httpClient.GetStringAsync(requestUri));
        }

        public static byte[] GetByteArray(this HttpClient httpClient, string requestUri)
        {
            return GetByteArray(httpClient, CreateUri(requestUri));
        }

        public static byte[] GetByteArray(this HttpClient httpClient, Uri requestUri)
        {
            if (httpClient == null)
            {
                throw new ArgumentNullException("httpClient");
            }
            return AsyncHelper.RunSync<byte[]>(() => httpClient.GetByteArrayAsync(requestUri));
        }

        public static Stream GetStream(this HttpClient httpClient, string requestUri)
        {
            return GetStream(httpClient, CreateUri(requestUri));
        }

        public static Stream GetStream(this HttpClient httpClient, Uri requestUri)
        {
            if (httpClient == null)
            {
                throw new ArgumentNullException("httpClient");
            }
            return AsyncHelper.RunSync<Stream>(() => httpClient.GetStreamAsync(requestUri));
        }

        public static HttpResponseMessage Get(this HttpClient httpClient, string requestUri)
        {
            return Get(httpClient,CreateUri(requestUri), HttpCompletionOption.ResponseContentRead, CancellationToken.None);
        }

        public static HttpResponseMessage Get(this HttpClient httpClient, Uri requestUri)
        {
            return Get(httpClient, requestUri, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
        }

        public static HttpResponseMessage Get(this HttpClient httpClient, string requestUri, HttpCompletionOption completionOption)
        {
            return Get(httpClient, CreateUri(requestUri), completionOption, CancellationToken.None);
        }

        public static HttpResponseMessage Get(this HttpClient httpClient, Uri requestUri, HttpCompletionOption completionOption)
        {
            return Get(httpClient, requestUri, completionOption, CancellationToken.None);
        }

        public static HttpResponseMessage Get(this HttpClient httpClient, string requestUri, CancellationToken cancellationToken)
        {
            return Get(httpClient, CreateUri(requestUri), HttpCompletionOption.ResponseContentRead, cancellationToken);
        }

        public static HttpResponseMessage Get(this HttpClient httpClient, Uri requestUri, CancellationToken cancellationToken)
        {
            return Get(httpClient, requestUri, HttpCompletionOption.ResponseContentRead, cancellationToken);
        }

        public static HttpResponseMessage Get(this HttpClient httpClient, string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            return Get(httpClient, CreateUri(requestUri), completionOption, cancellationToken);
        }

        public static HttpResponseMessage Get(this HttpClient httpClient, Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            return Send(httpClient,new HttpRequestMessage(HttpMethod.Get, requestUri), completionOption, cancellationToken);
        }

        public static HttpResponseMessage Post(this HttpClient httpClient, string requestUri, HttpContent content)
        {
            return Post(httpClient, CreateUri(requestUri), content, CancellationToken.None);
        }

        public static HttpResponseMessage Post(this HttpClient httpClient, Uri requestUri, HttpContent content)
        {
            return Post(httpClient, requestUri, content, CancellationToken.None);
        }

        public static HttpResponseMessage Post(this HttpClient httpClient, string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return Post(httpClient, CreateUri(requestUri), content, cancellationToken);
        }

        public static HttpResponseMessage Post(this HttpClient httpClient, Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = content
            };
            return Send(httpClient, request, cancellationToken);
        }

        public static HttpResponseMessage Put(this HttpClient httpClient, string requestUri, HttpContent content)
        {
            return Put(httpClient, CreateUri(requestUri), content, CancellationToken.None);
        }

        public static HttpResponseMessage Put(this HttpClient httpClient, Uri requestUri, HttpContent content)
        {
            return Put(httpClient, requestUri, content, CancellationToken.None);
        }

        public static HttpResponseMessage Put(this HttpClient httpClient, string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return Put(httpClient, CreateUri(requestUri), content, cancellationToken);
        }

        public static HttpResponseMessage Put(this HttpClient httpClient, Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, requestUri)
            {
                Content = content
            };
            return Send(httpClient, request, cancellationToken);
        }

        public static HttpResponseMessage Delete(this HttpClient httpClient, string requestUri)
        {
            return Delete(httpClient, CreateUri(requestUri));
        }

        public static HttpResponseMessage Delete(this HttpClient httpClient, Uri requestUri)
        {
            return Delete(httpClient, requestUri, CancellationToken.None);
        }

        public static HttpResponseMessage Delete(this HttpClient httpClient, string requestUri, CancellationToken cancellationToken)
        {
            return Delete(httpClient, CreateUri(requestUri), cancellationToken);
        }

        public static HttpResponseMessage Delete(this HttpClient httpClient, Uri requestUri, CancellationToken cancellationToken)
        {
            return Send(httpClient, new HttpRequestMessage(HttpMethod.Delete, requestUri), cancellationToken);
        }

        public static HttpResponseMessage Send(this HttpClient httpClient, HttpRequestMessage request)
        {
            return Send(httpClient, request, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
        }

        public static HttpResponseMessage Send(this HttpClient httpClient, HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Send(httpClient, request, HttpCompletionOption.ResponseContentRead, cancellationToken);
        }

        public static HttpResponseMessage Send(this HttpClient httpClient, HttpRequestMessage request, HttpCompletionOption completionOption)
        {
            return Send(httpClient, request, completionOption, CancellationToken.None);
        }

        public static HttpResponseMessage Send(this HttpClient httpClient, HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            if (httpClient == null)
            {
                throw new ArgumentNullException("httpClient");
            }
            return AsyncHelper.RunSync<HttpResponseMessage>(() => httpClient.SendAsync(request, completionOption, cancellationToken));
        }

        private static Uri CreateUri(string uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                return null;
            }
            return new Uri(uri, UriKind.RelativeOrAbsolute);
        }
    }
}
