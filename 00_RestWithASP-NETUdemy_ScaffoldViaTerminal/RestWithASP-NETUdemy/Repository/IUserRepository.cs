using RestWithASP_NETUdemy.Data.VO;
using RestWithASP_NETUdemy.Model;

namespace RestWithASP_NETUdemy.Repository;

public interface IUserRepository
{
    User? ValidateCredentials(UserVO user);
    User? RefreshUserInfo(User user);

    bool RevokeToken(string username);
    User? ValidateCredentials(string username);
}