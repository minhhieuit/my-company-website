using System;
using System.Collections.Generic;
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
    public class FeaturedWorkController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private IFormFile formFile;
        public FeaturedWorkController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _dbContext.FeaturedWorks.ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(FeaturedWork featuredWork, List<IFormFile> Thumbnail)
        {
            if (Thumbnail != null)
            {
                foreach (var item in Thumbnail)
                {
                    if (item.Length > 0)
                    {
                        var filePath = Path.Combine("",
                                            "Uploads", "Images", item.FileName.ToString().Trim('"'));
                        if (ModelState.IsValid)
                        {
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await item.CopyToAsync(stream);
                            }
                            featuredWork.Thumbnail += filePath + "|";
                        }
                    }
                }
                _dbContext.Add(featuredWork);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(featuredWork);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _dbContext.FeaturedWorks.SingleOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(FeaturedWork featuredWork, List<IFormFile> Thumbnail)
        {
            var model = await _dbContext.FeaturedWorks.SingleOrDefaultAsync(m => m.Id == featuredWork.Id);
            if (model == null)
            {
                return NotFound();
            }
            if (Thumbnail != null)
            {
                foreach (var item in Thumbnail)
                {
                    if (item.Length > 0)
                    {
                        var filePath = Path.Combine("",
                                            "Uploads", "Images", item.FileName.ToString().Trim('"'));
                        if (ModelState.IsValid)
                        {
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await item.CopyToAsync(stream);
                            }
                            model.Thumbnail += filePath + "|";

                        }
                    }
                }
                await TryUpdateModelAsync<FeaturedWork>(model);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(featuredWork);
        }
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _dbContext.FeaturedWorks.SingleOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            try
            {
                _dbContext.FeaturedWorks.Remove(model);
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