using System.Net.Http;

namespace OpenAuth
{
    public class AnonymousAuthenticator : IAuthenticator
    {
        public void Authenticate(HttpRequestMessage request, Credentials credentials)
        {
            // Do nothing. Retain your anonymity.
        }
    }
}
