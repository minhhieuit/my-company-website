using System.ComponentModel.DataAnnotations;

namespace MVC_Thehegeo.Models.BlogModels
{
    public class TeamInfo
    {
        public int Id { get; set; }
        public string FullNameVI { get; set; }
        public string FullNameEN { get; set; }
        public string FunctionVI { get; set; }
        public string FunctionEN { get; set; }
        public string Avatar { get; set; }
        [Required]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
        public string Email { get; set; }
        public string FacebookLink { get; set; }
        public string GooglePlusLink { get; set; }
        public string TwitterLink { get; set; }
    }
}