using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models.ViewModel
{
    public class SignupViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Correct Username!")]
        [Remote(action: "NameIsExist", controller: "Account")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Please enter Valid Email")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}",ErrorMessage ="Please Enter Valid Email")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Please enter Mobile Number")]
        [Display(Name = "Mobile Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Enter correct Password")]
        //[RegularExpression(@"^(?:._*[a-z]){8,}$",ErrorMessage ="Password must at least 8 character Long!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm Password")]
        [Compare("Password",ErrorMessage ="Password didn't match!!!")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
