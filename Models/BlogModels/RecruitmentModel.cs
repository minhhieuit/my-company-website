using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Thehegeo.Models.BlogModels
{
    public class Recruitment
    {
        public int Id { get; set; }
        public string TitleVI { get; set; }
        public string TitleEN { get; set; }
        public string ContentVI { get; set; }
        public string ContentEN { get; set; }
        public string ImagePath { get; set; }
    }
}
