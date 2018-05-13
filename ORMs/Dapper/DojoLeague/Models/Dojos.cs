using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DojoLeague.Models{
	public class Dojo:BaseEntity{
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
		public int id {get;set;}
		[Display(Name="Dojo Name")]
		[Required(ErrorMessage="You must enter a Dojo name.")]
		public string name {get; set;}
		[Required(ErrorMessage="You must enter a Dojo location.")]
		[Display(Name="Dojo Location")]
		public string location {get; set;}
		[Display(Name="About This Dojo (Optional)")]
		public string description {get; set;}
		public ICollection<Ninja> ninjas {get; set;}
	}
}
