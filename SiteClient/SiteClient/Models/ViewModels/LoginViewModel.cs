using System.ComponentModel.DataAnnotations;

namespace SiteClient.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Login name cannot be blank")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password cannot be blank")]
        public string Password { get; set; }
    }
}