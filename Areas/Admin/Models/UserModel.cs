using System.ComponentModel.DataAnnotations;
namespace mvc.Areas.Admin.Models
{
    public class User
    {
        public int UserId { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }
    }
}
