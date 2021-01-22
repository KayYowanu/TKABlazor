using System;
using System.ComponentModel.DataAnnotations;



namespace TKABlazor.Models
{
    public class TKACommentsModel
    {
        [Key]
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string Comment { get; set; }
        public string Username { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        public string IsDeleted { get; set; }
        public DateTime DeletedOn { get; set; } = DateTime.Now;

    }
}
