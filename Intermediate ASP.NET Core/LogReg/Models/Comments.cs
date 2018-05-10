using System;
using System.ComponentModel.DataAnnotations;

namespace LogReg.Models
{
    public class Comment : BaseEntity {
        public int commentor_id {get;set;}
        public int message_id {get; set;}
        public int id {get;set;}
        public string text {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
    }
    public class CommentViewModel : BaseEntity {
        [Required(ErrorMessage="Comment cannot be empty.")]
        public string text {get;set;}
    }
}