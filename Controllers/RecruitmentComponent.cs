using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Thehegeo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Thehegeo.Controllers
{
    [ViewComponent(Name ="Recruitment")]
    public class RecruitmentComponent : ViewComponent
    {
        private readonly ApplicationDbContext _dbContext;
        public RecruitmentComponent(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _dbContext.Recruitments.ToListAsync();
            return View(model);
        }
    }
}
