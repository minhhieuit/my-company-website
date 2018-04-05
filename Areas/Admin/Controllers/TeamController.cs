using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC_Thehegeo.Data;
using MVC_Thehegeo.Models.BlogModels;

namespace MVC_Thehegeo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private IFormFile formFile;
        public TeamController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var model = _dbContext.TeamInfos.ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeamInfo teamInfo, IFormFile Avatar)
        {
            if (Avatar != null)
            {
                long size = Avatar.Length;
                var filePath = Path.Combine("",
                                    "Uploads", "Images", Avatar.FileName.ToString().Trim('"'));
                formFile = Avatar;
                if (size > 0)
                {
                    if (ModelState.IsValid)
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                        teamInfo.Avatar = filePath;
                        _dbContext.Add(teamInfo);
                        await _dbContext.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            return View(teamInfo);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _dbContext.TeamInfos.SingleOrDefaultAsync(m => m.Id == id);
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TeamInfo teamInfo, IFormFile Avatar)
        {
            if (Avatar != null)
            {
                long size = Avatar.Length;
                var filePath = Path.Combine("",
                                    "Uploads", "Images", Avatar.FileName.ToString().Trim('"'));
                formFile = Avatar;
                if (size > 0)
                {
                    if (ModelState.IsValid)
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                        var model = await _dbContext.TeamInfos.SingleOrDefaultAsync(m=>m.Id == teamInfo.Id);
                        if(model == null)
                        {
                            return NotFound();
                        }
                        model.Avatar = filePath;
                        await TryUpdateModelAsync<TeamInfo>(model);
                        await _dbContext.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            return View(teamInfo);
        }
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _dbContext.TeamInfos.SingleOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            try
            {
                _dbContext.TeamInfos.Remove(model);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}