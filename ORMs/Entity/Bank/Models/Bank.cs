using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
/*
	Useful Annotations and Examples:

	[Required] - Makes a field required.
	[RegularExpression(@"[0-9]{0,}\.[0-9]{2}", ErrorMessage = "error Message")] - Put a REGEX string in here.
	[MinLength(100)] - Field must be at least 100 characters long.
	[MaxLength(1000)] - Field must be at most 1000 characters long.
	[Range(5,10)] - Field must be between 5 and 10 characters.
	[EmailAddress] - Field must contain an @ symbol, followed by a word and a period.
	[DataType(DataType.Password)] - Ensures that the field conforms to a specific DataType
*/

namespace Bank.Models{
	public class NotZero:ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			var d = Convert.ToDecimal(value);
			return d != 0;
		}
	}
	public class User:BaseEntity{
		[Key]
		public int id {get;set;}
		public string FirstName {get;set;}
		public string LastName {get;set;}
		public string EmailAddress {get;set;}
		public string Password {get;set;}
		public decimal balance {get;set;}
		public DateTime created_at {get;set;}
		public DateTime updated_at {get;set;}
		public List<Transaction> Transactions {get;set;}
		public User() {
			Transactions = new List<Transaction>();
			created_at = DateTime.Now;
			updated_at = DateTime.Now;
			balance = 0m;
		}
	}
	public class Transaction:BaseEntity{
		[Key]
		public int id {get;set;}
		public decimal amount {get;set;}
		public int UserId {get;set;}
		public User User {get;set;}
		public DateTime created_at {get;set;}
		public DateTime updated_at {get;set;}
		public Transaction() {
			created_at = DateTime.Now;
			updated_at = DateTime.Now;
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
	public class TransactionViewModel:BaseEntity{
		[Display(Name="Deposit / Withdraw")]
		[Required(ErrorMessage="You must deposit or withdraw something.")]
		[NotZero(ErrorMessage="You cannot deposit or withdraw nothing.")]
		public decimal? amount {get;set;}
	}
}