
using System.Net.Http;
namespace OpenAuth
{
	public class SimpleAuthenticator : IAuthenticator
	{
		private readonly string _usernameKey;
		private readonly string _username;
		private readonly string _passwordKey;
		private readonly string _password;

		public SimpleAuthenticator(string usernameKey, string username, string passwordKey, string password) {
			_usernameKey = usernameKey;
			_username = username;
			_passwordKey = passwordKey;
			_password = password;
		}

        public void Authenticate(HttpRequestMessage request, Credentials credentials)
		{
            
			//request.AddParameter(_usernameKey, _username);
			//request.AddParameter(_passwordKey, _password);
		}
	}
}
