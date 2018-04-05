using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Thehegeo.Models.BlogModels
{
    [Table("Post")]
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }

        public string Image { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}