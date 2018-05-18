using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApp.Models
{
    public class Student
    {
        public int ID { get; set; }
        
        [Required]
        [StringLength(50,ErrorMessage="Name cannot be longer than 50 characters.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage="Name must start with a capital letter and use alphabetic characters.")]
        [Display(Name="Last Name")]
        public string LastName { get; set; }
        
        [Required]
        [Display(Name="First Name")]
        [StringLength(50,ErrorMessage="Name cannot be longer than 50 characters.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage="Name must start with a capital letter and use alphabetic characters.")]
        [Column("FirstName")]
        public string FirstMidName { get; set; }


        [Display(Name="Date of Enrollment")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:M-dd-yyyy}",ApplyFormatInEditMode=true)]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name="Full Name")]
        public string FullName
        {
            get 
            {
                return LastName + ", " + FirstMidName;
            }
        }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}