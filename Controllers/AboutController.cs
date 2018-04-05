using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Thehegeo.Data;

namespace MVC_Thehegeo.Controllers
{
    public class AboutController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public AboutController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _dbContext.Abouts.SingleOrDefaultAsync(m => m.Id == id);
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }
    }
}