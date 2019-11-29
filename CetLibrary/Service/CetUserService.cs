using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CetLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace CetLibrary.Service
{
    public class CetUserService
    {
        private readonly LibraryDb _context;
        
        public CetUserService()
        {
            _context = new LibraryDb();
        }

        public bool IsPasswordTrue(CetUser user, string password)
        {
            return _context.CetUsers
                .Where(cetUser => cetUser.Id == user.Id)
                .Any(cetUser => cetUser.Password == HashPassword(password));
        }

        public CetUser Login(string userName, string password)
        {
            string hashedPassword = HashPassword(password);

            var loginUser = _context.CetUsers
                .Include(user => user.Role)
                .FirstOrDefault(u => u.UserName == userName && u.Password == hashedPassword);

            return loginUser;
        }

        public static string HashPassword(string plainPassword)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                var plainBytes = Encoding.UTF8.GetBytes(plainPassword);
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(plainBytes);

                // Convert byte array to a string 
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();

            }
        }

        public async void UpdatePassword(CetUser user, string newPassword)
        {
            string hashed = HashPassword(newPassword);
            user.Password = hashed;

            _context.Update(user);

            await _context.SaveChangesAsync();
        }

        public async void Register(CetUser user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
