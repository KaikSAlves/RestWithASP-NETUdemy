using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
using RestWithASP_NETUdemy.Configurations;
using RestWithASP_NETUdemy.Data.VO;
using RestWithASP_NETUdemy.Repository;

namespace RestWithASP_NETUdemy.Services.Implementations;

public class LoginServiceImplementation : ILoginService
{
    private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
    private TokenConfiguration _configuration;

    private IUserRepository _repository;
    private readonly ITokenService _tokenService;

    public LoginServiceImplementation(TokenConfiguration configuration, IUserRepository repository, ITokenService tokenService)
    {
        _configuration = configuration;
        _repository = repository;
        _tokenService = tokenService;
    }

    public TokenVO ValidateCredentials(UserVO userCredentials)
    {

        var user = _repository.ValidateCredentials(userCredentials);

        if (user == null) return null;
        
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
        };
        
        var accessToken = _tokenService.GenerateAccessToken(claims);
        var refreshToken = _tokenService.GenerateRefreshToken();
        
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry); 
        
        DateTime createDate = DateTime.Now;
        DateTime expiration = createDate.AddMinutes(_configuration.DaysToExpiry);

        _repository.RefreshUserInfo(user);
        
        return new TokenVO(
            true,
            createDate.ToString(DATE_FORMAT),
            expiration.ToString(DATE_FORMAT),
            accessToken,
            refreshToken    
            );   
    }
}