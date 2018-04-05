using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Thehegeo.Models.BlogModels
{
    [Table("About")]
    public class About
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string TitleVI { get; set; }
        public string TitleEN { get; set; }
        [Required]
        [Display(Name = "Content")]
        public string ContentVI { get; set; }
        public string ContentEN { get; set; }
        public string Thumbnail { get; set; }
    }
}