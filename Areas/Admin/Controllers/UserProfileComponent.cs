using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Thehegeo.Data;
using MVC_Thehegeo.Models;

namespace MVC_Thehegeo.Areas.Admin.Controllers
{   
    [ViewComponent(Name = "UserProfile")]
    public class UserProfileComponent : ViewComponent
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _manager; 
        public UserProfileComponent(ApplicationDbContext dbContext,UserManager<ApplicationUser> manager)
        {
            this._dbContext = dbContext;
            this._manager = manager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await GetCurrentUser();
            return View(model);
        }

        private async Task<ApplicationUser> GetCurrentUser()  
        {  
            return await _manager.GetUserAsync(HttpContext.User);  
        }  
    }
}