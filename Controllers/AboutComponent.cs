using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Thehegeo.Data;

namespace MVC_Thehegeo.Controllers
{
    [ViewComponent(Name = "About")]
    public class AboutComponent : ViewComponent
    {
        private readonly ApplicationDbContext _dbContext;
        public AboutComponent(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _dbContext.Abouts.ToListAsync();
            return View(model);
        }
    }
}