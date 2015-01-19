using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenAuth
{
    public class ApiResponseMessage : HttpResponseMessage, IApiResponseMessage
    {
    }

    public class ApiResponseMessage<T> : ApiResponseMessage
    {
        public T Data { get; set; }
    }
}
