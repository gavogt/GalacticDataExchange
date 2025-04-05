using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange.Shared
{
    public class LoginInputModel
    {
        public string Email;
        public string Password;

        public LoginInputModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
