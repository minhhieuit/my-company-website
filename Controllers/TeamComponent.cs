using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Thehegeo.Data;

namespace MVC_Thehegeo.Controllers
{
    [ViewComponent(Name = "Team")]
    public class TeamComponent : ViewComponent
    {
        private readonly ApplicationDbContext _dbContext;
        public TeamComponent(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _dbContext.TeamInfos.ToListAsync();
            return View(model);
        }
    }
}