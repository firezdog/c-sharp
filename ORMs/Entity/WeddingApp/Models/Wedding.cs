using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace WeddingApp.Models{
	
	public class AfterNow:ValidationAttribute
	{		
        public override bool IsValid(object value)
        {
            var d = Convert.ToDateTime(value);
            return d > DateTime.Now;
        }
	}

	public class User:BaseEntity{
		public int UserId {get;set;}
		public string FirstName {get;set;}
		public string LastName {get;set;}
		public string EmailAddress {get;set;}
		public string Password {get;set;}
		public List<Wedding> PlannedWeddings {get;set;}
		public List<Attendance> Weddings {get;set;}
		public DateTime Created_At {get;set;}
		public DateTime Updated_At {get;set;}
		public User() {
			Created_At = DateTime.Now;
			Updated_At = DateTime.Now;
			PlannedWeddings = new List<Wedding>();
			Weddings = new List<Attendance>();
		}
	}

	public class UserViewModel:BaseEntity{
		
		[Display(Name="First Name")]
		[Required(ErrorMessage="This field is required.")]
		[MinLength(4,ErrorMessage="Must be at least 4 characters.")]
		public string FirstName {get;set;}

		[Display(Name="Last Name")]
		[Required(ErrorMessage="This field is required.")]
		[MinLength(4,ErrorMessage="Must be at least 4 characters.")]
		public string LastName {get;set;}

		[Display(Name="Email")]
		[Required(ErrorMessage="This field is required.")]
		[EmailAddress]
		public string EmailAddress {get;set;}

		[Display(Name="Password")]
		[Required(ErrorMessage="This field is required.")]
		[DataType(DataType.Password)]
		public string Password {get;set;}
		
		[Display(Name="Confirm Password")]
		[DataType(DataType.Password)]
		[CompareAttribute("Password",ErrorMessage="Password and confirmation do not match.")]
		public string Confirmation {get;set;}

	}

	public class Wedding:BaseEntity{
		public int WeddingId {get;set;}
		public string WedderOne {get;set;}
		public string WedderTwo {get;set;}
		public DateTime Date {get;set;}
		public string Address {get;set;}
		public int UserId {get;set;}
		public User User {get;set;}
		public List<Attendance> Users {get;set;}
		public DateTime Created_At {get;set;}
		public DateTime Updated_At {get;set;}
		public Wedding() {
			Users = new List<Attendance>();
			Created_At = DateTime.Now;
			Updated_At = DateTime.Now;
		}
	}
	public class WeddingViewModel:BaseEntity{
		[Required]
		[Display(Name="Wedder One")]
		public string WedderOne {get;set;}
		
		[Required]
		[Display(Name="Wedder Two")]
		public string WedderTwo {get;set;}
		
		[Required]
		[Display(Name="Wedding Date")]
		[AfterNow(ErrorMessage="Wedding must be in the future.")]
		public DateTime? Date {get;set;}
		
		[Required]
		[Display(Name="Wedding Location")]
		public string Address {get;set;}

	}

	public class Attendance:BaseEntity{
		public int AttendanceId {get;set;}
		public int UserId {get;set;}
		public User User {get;set;}
		public int WeddingId {get;set;}
		public Wedding Wedding {get;set;}
	}
}
