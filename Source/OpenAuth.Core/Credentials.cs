using System.Diagnostics.CodeAnalysis;

namespace OpenAuth
{
    public class Credentials
    {
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes"
            , Justification = "Credentials is immutable")]
        public readonly static Credentials Anonymous = new Credentials();

        private Credentials()
        {
            AuthenticationType = AuthenticationType.Anonymous;
        }

        public Credentials(string token)
        {
            UserName = null;
            Password = token;
            AuthenticationType = AuthenticationType.Oauth;
        }

        public Credentials(string userName, string password)
        {
            UserName = userName;
            Password = password;
            AuthenticationType = AuthenticationType.Basic;
        }

        public string UserName
        {
            get;
            private set;
        }

        public string Password
        {
            get;
            private set;
        }

        public AuthenticationType AuthenticationType
        {
            get; 
            private set;
        }
    }
}