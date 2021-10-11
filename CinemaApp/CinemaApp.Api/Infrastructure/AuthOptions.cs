using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace CinemaApp.API.Infrastructure
{
    public class AuthOptions
    {
        public const string ISSUER = "CinemaApp";
        public const string AUDIENCE = "CinemaAppClient";
        private const string KEY = "customSecretKey!";

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
