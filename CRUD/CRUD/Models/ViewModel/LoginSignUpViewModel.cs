using System.ComponentModel.DataAnnotations;

namespace CRUD.Models.ViewModel
{
    public class LoginSignUpViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
        [Display(Name ="Remember me")]
        public bool IsRemember { get; set; }
    }
}
