using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC_Thehegeo.Data;
using MVC_Thehegeo.Models.BlogModels;
using MVC_Thehegeo.Models.Repository;

namespace MVC_Thehegeo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
       
        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cate = await _dbContext.Categories.ToListAsync();
            return View(cate);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Alias")] Category model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(model);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cate = await _dbContext.Categories.SingleOrDefaultAsync(m => m.Id == id);
            await TryUpdateModelAsync<Category>(cate, "", m => m.Name, m => m.Alias);
            if (cate == null)
            {
                return NotFound();
            }
            return View(cate);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost([Bind("Id,Name,Alias")] Category category)
        {
            if (ModelState.IsValid)
            {
                var cate = await _dbContext.Categories.SingleOrDefaultAsync(m => m.Id == category.Id);
                await TryUpdateModelAsync<Category>(cate, "", m => m.Name, m => m.Alias);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            var model = await _dbContext.Categories.AsNoTracking().SingleOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _dbContext.Categories.Remove(model);
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
            var model = await _dbContext.Categories.AsNoTracking().SingleOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _dbContext.Categories.Remove(model);
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