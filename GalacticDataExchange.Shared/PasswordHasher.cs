using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Konscious.Security.Cryptography;

namespace GalacticDataExchange.Shared
{
    internal class PasswordHasher
    {
        public async Task<string> HashPasswordAsync(string password)
        {
            // 16 byte salt
            byte[] salt = new byte[16];
            RandomNumberGenerator.Fill(salt);

            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 8,
                Iterations = 4,
                MemorySize = 64 * 1024
            };

            // 16 byte hash
            Byte[] hash = await argon2.GetBytesAsync(16);

            // Combine salt and hash
            return $"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
        }
    }
}
