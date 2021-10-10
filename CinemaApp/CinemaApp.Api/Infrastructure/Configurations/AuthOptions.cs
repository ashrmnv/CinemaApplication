using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CinemaApp.API.Infrastructure.Configurations
{
    public class AuthOptions
    {
        public const string ISSUER = "CinemaApp"; 
        public const string AUDIENCE = "CinemaAppClient"; 
        const string KEY = "customSecretKey!"; 
        public const int LIFETIME = 1; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
