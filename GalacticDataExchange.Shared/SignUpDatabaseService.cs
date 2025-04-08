using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange.Shared
{
    public class SignUpDatabaseService
    {
        private readonly DataDBContext _context;
        public SignUpDatabaseService(DataDBContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertUserIntoDatabase(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));

            }

            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                int affectedRows = await _context.SaveChangesAsync();
                return affectedRows > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting user: {ex.Message}");
                return false;

            }
        }
    }
}
