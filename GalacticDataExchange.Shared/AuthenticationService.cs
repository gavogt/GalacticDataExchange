using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Konscious.Security.Cryptography;

namespace GalacticDataExchange.Shared
{
    public class AuthenticationService
    {
        private readonly DataDBContext _context;

        public AuthenticationService(DataDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AutheticateUserAsync(string email, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);

            if(user == null)
            {
                return false;
            }

            var tokens = user.Password.Split('.');
            if (tokens.Length != 2)
            {
                return false;
            }

            byte[] salt = Convert.FromBase64String(tokens[0]);

            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 8,
                Iterations = 4,
                MemorySize = 64 * 1024
            };

            string computedHash = Convert.ToBase64String(await argon2.GetBytesAsync(16));
            return computedHash == tokens[1];
        }   
    }
}
