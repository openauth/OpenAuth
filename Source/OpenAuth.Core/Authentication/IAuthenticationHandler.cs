using System.Net.Http;
namespace OpenAuth
{
    public interface IAuthenticator
    {
        void Authenticate(HttpRequestMessage request, Credentials credentials);
    }
}