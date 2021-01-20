using System;
using System.ComponentModel.DataAnnotations;



namespace TKABlazor.Models
{
    public class TKAPostsModel
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        public string PostPublished { get; set; }
        public string PostApproved { get; set; }
        public string IsDeleted { get; set; }
        public DateTime DeletedOn { get; set; } = DateTime.Now;

    }
}
