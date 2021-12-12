using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawApp.Common.Models.Dto.AuthModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is empty")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
