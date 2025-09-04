using System.Security.Cryptography;
using System.Text;
using RestWithASP_NETUdemy.Data.VO;
using RestWithASP_NETUdemy.Model;
using RestWithASP_NETUdemy.Model.Context;

namespace RestWithASP_NETUdemy.Repository;

public class UserRepository : IUserRepository
{
    private readonly MySqlContext _context;

    public UserRepository(MySqlContext context)
    {
        _context = context;
    }

    public User ValidateCredentials(UserVO user)
    {
        var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
        
        return _context.Users.FirstOrDefault(u => (u.UserName == user.UserName && u.Password == pass));
    }

    public User RefreshUserInfo(User user)
    {
        if (!_context.Users.Any(u => u.Id == user.Id)) return null;

        var result = _context.Users.SingleOrDefault(x => x.Id.Equals(user.Id));

        if (result != null)
        {
            try
            {
                _context.Users.Entry(result).CurrentValues.SetValues(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        return result;
    }

    private object ComputeHash(string password, SHA256CryptoServiceProvider algorithm)
    {
        Byte[] inputBytes = Encoding.UTF8.GetBytes(password);
        Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
        return BitConverter.ToString(hashedBytes);
    }
}