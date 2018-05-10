using System;
using System.ComponentModel.DataAnnotations;

namespace LogReg.Models
{
    public class Message : BaseEntity {
        public int user_id {get;set;}
        public int id {get;set;}
        public string text {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
    }
    public class MessageViewModel : BaseEntity {
        [Required(ErrorMessage="Message text cannot be empty.")]
        public string text {get;set;}
    }
}