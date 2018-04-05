using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Thehegeo.Data;
using MVC_Thehegeo.Models.BlogModels;

namespace MVC_Thehegeo.Controllers
{
    [ViewComponent(Name = "CompanyInfo")]
    public class CompanyInfoComponent : ViewComponent
    {
        private readonly ApplicationDbContext _dbContext;
        public CompanyInfoComponent(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _dbContext.CompanyInfos.ToListAsync();
            if(model == null)
            {
                return View(new CompanyInfo()
                {
                    Id = 1,
                    Email = "geotech@thehegeo.com",
                    Phone = "+84 123 123 123",
                    AddressEN = "7 Floor, Song Da Building, Pham Hung Street, Hanoi",
                    AddressVI = "Tầng 7, Khu B, Tòa nhà sông Đà, đường Phạm Hùng, Hà Nội",
                });
            }
            return View(model);
        }
    }
}