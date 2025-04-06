﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticDataExchange.Shared
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email;
        [Required(ErrorMessage = "Password is required.")]
        public string Password;
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName;
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName;

    }
}
