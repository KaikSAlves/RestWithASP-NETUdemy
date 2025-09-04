using System.Security.Claims;

namespace RestWithASP_NETUdemy.Services;

public interface ITokenInterface
{
    string GenerateAccessToken(IEnumerable<Claim> claims);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}