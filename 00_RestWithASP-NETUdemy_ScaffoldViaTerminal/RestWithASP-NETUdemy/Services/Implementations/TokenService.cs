using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;
using RestWithASP_NETUdemy.Configurations;

namespace RestWithASP_NETUdemy.Services.Implementations;

public class TokenService : ITokenService
{
    private TokenConfiguration _config;

    public TokenService(TokenConfiguration config)
    {
        _config = config;
    }

    public string GenerateAccessToken(IEnumerable<Claim> claims)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Secret));
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var tokenOptions = new JwtSecurityToken(
            issuer: _config.Issuer,
            audience: _config.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_config.Minutes),
            signingCredentials: signingCredentials
            );
        
        string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions); 
        
        return tokenString;
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Secret)),
            ValidateLifetime = false
        };
        
        var  tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;
        
        
        ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null  
            || !jwtSecurityToken.Header.Alg.
                Equals(SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCulture)) throw new SecurityTokenException("Invalid token");
        return principal;
    }
}