using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange.Shared
{
    public class LoginInputModel
    {
        private string _email;
        private string _password;

        public LoginInputModel(string email, string password)
        {
            _email = email;
            _password = password;
        }
    }
}
