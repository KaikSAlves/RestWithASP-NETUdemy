using Microsoft.AspNetCore.Identity;
using RestWithASP_NETUdemy.Data.VO;

namespace RestWithASP_NETUdemy.Services;

public interface ILoginService
{
    
    bool RevokeToken(string username);
    TokenVO ValidateCredentials(UserVO user);
    TokenVO ValidateCredentials(TokenVO token);
}