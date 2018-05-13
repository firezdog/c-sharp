using System.ComponentModel.DataAnnotations;

namespace DojoLeague.Models
{
    public class Ninja:BaseEntity{
        public int id {get;set;}
        [Display(Name="Ninja Name")]
        [Required(ErrorMessage="Ninja name is required.")]
        public string name {get;set;}
        [Display(Name="Ninja Level (1-10)")]
        [Required(ErrorMessage="Ninja level is required.")]
        [Range(1,10,ErrorMessage="Ninja level must be between 1 and 10.")]
        public  int? level {get;set;}
        [Display(Name="Ninja Description (Optional)")]
        public string description {get;set;}
        [Display(Name="Assigned Dojo?")]
        public int? dojos_id {get;set;}
        public Dojo dojo {get;set;}
    }
}