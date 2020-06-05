using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCompany.Core.Services.Communication.Resources
{
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
