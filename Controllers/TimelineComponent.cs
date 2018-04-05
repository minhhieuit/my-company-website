using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Thehegeo.Data;

namespace MVC_Thehegeo.Controllers
{
    [ViewComponent(Name = "Timeline")]
    public class TimelineComponent : ViewComponent
    {
        private readonly ApplicationDbContext _dbContext;
        public TimelineComponent(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _dbContext.TimeLines.ToListAsync();
            return View(model);
        }
    }
}