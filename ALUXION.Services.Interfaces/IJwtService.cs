using ALUXION.Domain;
using Google.Apis.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ALUXION.Services.Interfaces
{
    public interface IJwtService
    {
        string Generate(User user);
        string GetEmail(ClaimsPrincipal user);
        JwtSecurityToken Verify(string jwt);
        Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(string token);
        
    }
}