using System.Runtime.Intrinsics.Arm;
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

    public User? ValidateCredentials(UserVO user)
    {
        string pass = ComputeHash(user.Password, SHA256.Create());
        
        //parte de teste
        /*
        var passLeandro = _context.Users.First().Password;
        Console.WriteLine(passLeandro);
        Console.WriteLine("Senha leandro: " + passLeandro.Replace("-", ""));
        Console.WriteLine("Senha descriptografada: " + pass);
        Console.WriteLine("Sao iguais? " + (passLeandro.Replace("-", "").Equals(pass)));
        
        */
        
        return _context.Users.FirstOrDefault(u => 
            (u.UserName == user.UserName && u.Password.Replace("-", "").Equals(pass)));
    }

    public User? RefreshUserInfo(User user)
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

    private string ComputeHash(string password, HashAlgorithm hashAlgorithm)
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(password);
        byte[] hashedBytes = hashAlgorithm.ComputeHash(inputBytes);
        
        var sBuilder = new StringBuilder();
        foreach (var item in hashedBytes)
        {
            sBuilder.Append(item.ToString("x2"));
        }
        
        return sBuilder.ToString().ToUpper();
    }
}