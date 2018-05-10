using System.ComponentModel.DataAnnotations;

namespace LogReg.Models
{
    public abstract class BaseEntity {}
    public class User : BaseEntity {
        [Required(ErrorMessage="First name is required.")]
        [MinLength(2,ErrorMessage="First name must be at least 2 characters long.")]
        [RegularExpression(@"^[a-zA-Z]+$",ErrorMessage="Letters only.")]
        public string FirstName {get;set;}
        [Required(ErrorMessage="Last name is required.")]
        [MinLength(2,ErrorMessage="Last name must be at least 2 characters long.")]
        [RegularExpression(@"^[a-zA-Z]+$",ErrorMessage="Letters only.")]
        public string LastName {get;set;}
        [Required(ErrorMessage="Email is required.")]
        [EmailAddress(ErrorMessage="Invalid email address.")]
        public string Email {get; set;}
        [Required(ErrorMessage="Password is required.")]
        [MinLength(8,ErrorMessage="Password must be at least 8 characters long.")]
        public string Password {get; set;}
        [Compare("Password",ErrorMessage="Password and confirmation do not match.")]
        public string Confirmation {get;set;}
    }
}