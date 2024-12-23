using System.ComponentModel.DataAnnotations;

namespace QuanLySoTietKiem.Models.AccountModels.LoginModel
{
    public class LoginModel
    {
        /*[Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]*/
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
