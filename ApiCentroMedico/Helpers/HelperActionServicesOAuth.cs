using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiCentroMedico.Helpers
{
    public class HelperActionServicesOAuth
    {
        public string Issuer;
        public string Audience;
        public string SecretKey;

        public HelperActionServicesOAuth(SecretClient secretClient)
        {
            KeyVaultSecret secretIssuer =  secretClient.GetSecret("secretIssuer");
            this.Issuer = secretIssuer.Value;
            KeyVaultSecret secretAudience = secretClient.GetSecret("secretAudience");
            this.Audience = secretAudience.Value;
            KeyVaultSecret secretKey = secretClient.GetSecret("secretKey");
            this.SecretKey = secretKey.Value;
        }

        public SymmetricSecurityKey GetKeyToken()
        {
            byte[] data = Encoding.UTF8.GetBytes(this.SecretKey);
            return new SymmetricSecurityKey(data);
        }

        public Action<JwtBearerOptions> GetJwtBearerOptions()
        {
            Action<JwtBearerOptions> options = new Action<JwtBearerOptions>(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = this.Issuer,
                    ValidAudience = this.Audience,
                    IssuerSigningKey = this.GetKeyToken()
                };
            });
            return options;
        }

        public Action<AuthenticationOptions> GetAuthenticationSchema()
        {
            Action<AuthenticationOptions> options = new Action<AuthenticationOptions>(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });
            return options;
        }
    }
}
