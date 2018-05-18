using System;
using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Models.SchoolViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:M-dd-yyyy}",ApplyFormatInEditMode=true)]
        public DateTime? EnrollmentDate {get;set;}
        public int StudentCount {get;set;}
    }
}