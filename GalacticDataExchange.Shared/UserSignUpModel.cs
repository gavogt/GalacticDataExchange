using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange.Shared
{
    public class UserSignUpModel
    {
        [Required(ErrorMessage = "Email is required."), EmailAddress]
        public string Email = String.Empty;
        [Required(ErrorMessage = "Password is required.")]
        public string Password = String.Empty;
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName = String.Empty;
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName = String.Empty;

    }
}
