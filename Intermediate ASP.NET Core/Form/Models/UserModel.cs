using System.ComponentModel.DataAnnotations;

namespace Form.Models
{
    public abstract class BaseEntity {}
    public class User : BaseEntity {
        [Required(ErrorMessage="First name is required.")]
        [MinLength(4, ErrorMessage="First name must be at least 4 characters long.")]
        public string FirstName {get;set;}
        [Required(ErrorMessage="Last name is required.")]
        [MinLength(4, ErrorMessage="Last name must be at least 4 characters long.")]
        public string LastName {get;set;}
        [Required(ErrorMessage="Age is required.")]
        [Range(0,int.MaxValue, ErrorMessage="Age cannot be negative.")]
        public int? Age {get; set;}
        [Required(ErrorMessage="Email is required.")]
        [EmailAddress(ErrorMessage="Email address format is invalid.")]
        public string Email {get;set;}
        [Required(ErrorMessage="Password is required.")]
        [MinLength(8)]
        public string Password {get;set;}
        [Compare(nameof(Password), ErrorMessage="Password and confirmation do not match.")]
        public string Confirmation {get;set;}
    }
}