using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Mthembu_Funeral_Policy_App.Models
{
    public class Login
    {
        public int id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        [MinLength(8)]
        public string Password { get; set; }

        public string LoginErrorMessage { get; set; }

        public Nullable<bool> Role { get; set; }
    }

}