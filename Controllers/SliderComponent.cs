using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Thehegeo.Data;

namespace MVC_Thehegeo.Controllers
{
    [ViewComponent(Name = "Slider")]
    public class SliderComponent : ViewComponent
    {
        private readonly ApplicationDbContext _dbContext;
        public SliderComponent(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _dbContext.Sliders.ToListAsync();
            return View(model);
        }
    }
}