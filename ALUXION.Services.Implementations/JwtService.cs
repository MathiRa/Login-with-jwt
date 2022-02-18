using ALUXION.Services.Interfaces;
using Google.Apis.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ALUXION.Settings;
using ALUXION.Domain;

namespace ALUXION.Services.Implementations
{
    public class JwtService : IJwtService
    {
        private readonly ALUXIONSettings _settings;
        public JwtService(IOptions<ALUXIONSettings> settings)
        {
            _settings = (ALUXIONSettings)settings.Value;
        }

        public string Generate(User user)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecureKeyJwt));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


                var claims = new[] {
                new Claim("FirstName",user.FirstName),
                new Claim("LastName",user.LastName),
                new Claim("Email", user.Email),
                new Claim("PhoneNumber", user.PhoneNumber),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

                var token = new JwtSecurityToken(_settings.IssuerJwt,
                  _settings.IssuerJwt,
                  claims,
                  expires: DateTime.Now.AddMinutes(30),
                  signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public string GetEmail(ClaimsPrincipal user)
        {
            try
            {
                List<Claim> claims = user.Claims.ToList();
                string email = claims.FirstOrDefault(c => c.Type == "Email").Value.ToString();
                return email;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public JwtSecurityToken Verify(string jwt)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_settings.SecureKeyJwt);
            tokenHandler.ValidateToken(jwt, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);

            return (JwtSecurityToken)validatedToken;
        }

        public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(string token)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>() { _settings.GoogleClientId }
                };
                var payload = await GoogleJsonWebSignature.ValidateAsync(token, settings);
                return payload;
            }
            catch (Exception ex)
            {
                //log an exception
                return null;
            }
        }


    }
}
