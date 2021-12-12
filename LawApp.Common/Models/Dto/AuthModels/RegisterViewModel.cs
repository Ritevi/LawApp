using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawApp.Common.Models.Dto.AuthModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email is Empty")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "PasswordMismatch")]
        public string ConfirmPassword { get; set; }
    }
}
