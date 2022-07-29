using System.ComponentModel.DataAnnotations;

namespace POSSolution.Core.Common.Models;
public class Identity : BaseModel
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public int Mobile { get; set; }
    public string Email { get; set; }

}

public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }


 public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
