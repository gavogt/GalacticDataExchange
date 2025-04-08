using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange.Shared
{
    public class LoginInputModel
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email = String.Empty;
        [Required(ErrorMessage = "Password is required.")]
        public string Password = String.Empty;

    }
}
