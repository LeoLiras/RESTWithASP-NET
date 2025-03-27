using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using RESTWithASP_NET.Data.VO;
using RESTWithASP_NET.Model;
using RESTWithASP_NET.Model.Context;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace RESTWithASP_NET.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _context;

        public UserRepository(MySQLContext context)
        {
            _context = context;
        }

        public users ValidateCredentials(UserVO user)
        {
            var pass = ComputeHash(user.Password, SHA256.Create());
            return _context.Users.FirstOrDefault(u => (u.user_name == user.UserName) && (u.password == pass));  
        }

        public users ValidateCredentials(string username)
        {
            return _context.Users.SingleOrDefault(u => u.user_name == username);
        }

        public bool RevokeToken(string username)
        {
            var user = _context.Users.SingleOrDefault(u => u.user_name == username);

            if (user is null) return false;

            user.refresh_token = null;
            _context.SaveChanges();

            return true;
        }

        public users RefreshUserInfo(users user)
        {
            if (!_context.Users.Any(u => u.id.Equals(user.id))) return null;

            var result = _context.Users.SingleOrDefault(p => p.id.Equals(user.id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
                return result;

        }

        private string ComputeHash(string input, HashAlgorithm algorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            var builder = new StringBuilder();

            foreach (var item in hashedBytes)
            {
                builder.Append(item.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
