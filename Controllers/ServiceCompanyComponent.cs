using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Thehegeo.Data;

namespace MVC_Thehegeo.Controllers
{
    [ViewComponent(Name = "ServiceCompany")]
    public class ServiceCompanyComponent : ViewComponent
    {
        private readonly ApplicationDbContext _dbContext;
        public ServiceCompanyComponent(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _dbContext.ServiceCompanys.ToListAsync();
            return View(model);
        }
    }
}