using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC_Thehegeo.Data;
using MVC_Thehegeo.Models.BlogModels;

namespace MVC_Thehegeo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AboutController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public AboutController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var model = _dbContext.Abouts.ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("TitleVI,TitleEN,ContentVI,ContentEN,Thumbnail")]About about)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(about);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(about);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _dbContext.Abouts.SingleOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,TitleVI,TitleEN,ContentVI,ContentEN,Thumbnail")] About about)
        {
            if (ModelState.IsValid)
            {
                var model = await _dbContext.Abouts.SingleOrDefaultAsync(m => m.Id == about.Id);
                await TryUpdateModelAsync<About>(model, "", m => m.Id, m => m.TitleVI, m => m.TitleEN, m => m.ContentVI, m => m.ContentEN, m => m.Thumbnail);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(about);
        }
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            var model = await _dbContext.Abouts.AsNoTracking().SingleOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _dbContext.Abouts.Remove(model);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _dbContext.Abouts.AsNoTracking().SingleOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _dbContext.Abouts.Remove(model);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }
    }
}