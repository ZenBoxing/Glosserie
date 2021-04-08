using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glosserie.WPF.Library.Models
{
    public class RegistrationModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
