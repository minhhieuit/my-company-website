using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Thehegeo.Models.BlogModels
{
    [Table("Service")]
    public class ServiceCompany
    {   
        [Key]
        public int Id {get;set;}
        [Required]
        public string TitleVI { get; set; }
        public string TitleEN { get; set; }
        [Required]
        public string ContentVI { get; set; }
        public string ContentEN { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required]
        public string ImageLink { get; set; }
        public string IntroVI { get; set; }
        public string IntroEN { get; set; }
    }
}