using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class RegisterViewModel
    {
        //public int Id { get; set; }
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name is required.")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; }
        [Required(ErrorMessage ="Password is required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Display(Name = "Contact Number")]
        [Required(ErrorMessage = "Contact Number is required.")]
        public string? ContactNumber { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; } 
    }
}