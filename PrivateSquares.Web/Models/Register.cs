using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrivateSquares.Web.Models
{
    public class Register
    {
        [Required(ErrorMessage ="Email id is required")]
        [StringLength(maximumLength:100, ErrorMessage ="Invalid email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [StringLength(30, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters and no more than 30 characters")]
        [RegularExpression(@"^.*(?=.*[!@#$%^&*\(\)_\-+=]).*$", ErrorMessage = "Password must be include at least one upper case letter, one lower case letter, and one numeric digit")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password must be match")]
        public string ConfirmPassword { get; set; }
    }
}
