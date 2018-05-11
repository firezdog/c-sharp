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

namespace LostInWoods.Models{
	public class Trail:BaseEntity{
		public int id {get; set;}
		public string trail_name {get; set;}
		public string trail_description {get; set;}
		public double trail_length {get; set;}
		public int elevation_change {get; set;}
		public double latitude {get; set;}
		public double longitude {get; set;}
		public DateTime created_at {get; set;}
		public DateTime updated_at {get; set;}
	}
	public class TrailViewModel:BaseEntity{
		[Display(Name = "Trail Name")]
		[Required(ErrorMessage="You must specify a trail name.")]
		public string trail_name {get;set;}
		[Display(Name = "Trail Description")]
		[MinLength(10,ErrorMessage="Your description must be at least ten characters long.")]
		public string trail_description {get; set;}
		[Display(Name = "Trail Length (miles)")]
		[Required(ErrorMessage="Please enter a trail length in miles.")]
		[Range(0,double.MaxValue,ErrorMessage="No negative lengths.")]
		public double? trail_length {get; set;}
		[Display(Name = "Elevation Change (feet)")]
		[Required(ErrorMessage="Please enter elevation change of the trail in feet.")]
		[Range(0,int.MaxValue,ErrorMessage="No negative elevation changes.")]
		public int? elevation_change {get; set;}
		[Display(Name = "Latitude (-90 to 90 degrees)")]
		[Required(ErrorMessage="Please enter the latitude for the trail in degrees.")]
		[Range(-90,90,ErrorMessage="Latitudes range from -90 to 90 degrees.")]
		public double? latitude {get; set;}
		[Display(Name = "Longitude (-180 to 180 degrees)")]
		[Required(ErrorMessage="Please enter the longitude for the trail in degrees.")]
		[Range(-180,180,ErrorMessage="Longitudes range from -180 to 180 degrees.")]
		public double? longitude {get; set;}
	}
}