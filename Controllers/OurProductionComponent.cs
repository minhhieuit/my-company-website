using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Thehegeo.Data;

namespace MVC_Thehegeo.Controllers
{
    [ViewComponent(Name = "OurProduction")]
    public class OurProductionComponent : ViewComponent
    {
        private readonly ApplicationDbContext _dbContext;
        public OurProductionComponent(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _dbContext.FeaturedWorks.ToListAsync();
            return View(model);
        }
    }
}