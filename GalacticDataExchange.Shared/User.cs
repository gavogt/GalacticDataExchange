using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange.Shared
{
    internal class User
    {
        [Key]
        public Guid ID = Guid.NewGuid();

        // Common properties
        private string _email;
        private string _password;
        private string _firstName;
        private string _lastName;

        public User(string email, string password, string firstName, string lastName)
        {
            _email = email;
            _password = password;
            _firstName = firstName;
            _lastName = lastName;
        }
    }
}
