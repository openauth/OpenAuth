using System;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http;
using System.Text;

namespace OpenAuth
{
    public class BasicAuthenticator : IAuthenticator
    {
        public void Authenticate(HttpRequestMessage request, Credentials credentials)
        {
            Debug.Assert(credentials.Password != null, "It should be impossible for the password to be null");

            var header = string.Format(
                CultureInfo.InvariantCulture,
                "Basic {0}",
                Convert.ToBase64String(Encoding.UTF8.GetBytes(
                    string.Format(CultureInfo.InvariantCulture, "{0}:{1}", credentials.UserName, credentials.Password))));

            //request.Headers.Authorization = header;
        }
    }
}
