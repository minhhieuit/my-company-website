using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Thehegeo.Data;

namespace MVC_Thehegeo.Controllers
{
    [ViewComponent(Name = "Partner")]
    public class PartnerComponent : ViewComponent
    {
        private readonly ApplicationDbContext _dbContext;
        public PartnerComponent(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _dbContext.Partners.ToListAsync();
            return View(model);
        }
    }
}