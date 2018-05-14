using System.ComponentModel.DataAnnotations;
using System;

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

namespace RESTauranter.Models{
	public class BeforeToday:ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			DateTime d = Convert.ToDateTime(value);
			return d < DateTime.Today;
		}
	}
	public class Review:BaseEntity{
		[Key]
		public int id {get;set;}
		[Display(Name="Reviewer")]
		[Required(ErrorMessage="Reviewer is required.")]
		public string reviewer {get;set;}
		[Display(Name="Restaurant")]
		[Required(ErrorMessage="Restaurant is required.")]
		public string restaurant {get;set;}
		[Required(ErrorMessage="Rating is required")]
		[Display(Name="Rating")]
		public int rating {get;set;}
		[Display(Name="Review")]
		[Required(ErrorMessage="Review is required.")]
		[MinLength(10,ErrorMessage="Review must be at least 10 characters.")]
		public string review {get;set;}
		[Display(Name="Date Visited")]
		[Required(ErrorMessage="Date of visit is required.")]
		[BeforeToday(ErrorMessage="Date of visit must be in the past.")]
		public DateTime? date_visited {get;set;}
		public DateTime created_at {get;set;}
		public DateTime updated_at {get;set;}
	}
}
