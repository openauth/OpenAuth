using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenAuth
{
    public class ApiRequestMessage : HttpRequestMessage, IApiRequestMessage
    {
        protected readonly HttpRequestMessage _request;

        public ApiRequestMessage()
            : this(new HttpRequestMessage())
        {

        }

        protected ApiRequestMessage(HttpRequestMessage request)
        {
            this._request = request;
        }
    }
}
