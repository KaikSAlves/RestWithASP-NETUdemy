using RestWithASP_NETUdemy.Data.VO;

namespace RestWithASP_NETUdemy.Services;

public interface ILoginService
{
    TokenVO ValidateCredentials(UserVO user);
}