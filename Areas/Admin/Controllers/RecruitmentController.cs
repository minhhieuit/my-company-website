using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Thehegeo.Data;
using MVC_Thehegeo.Models.BlogModels;

namespace MVC_Thehegeo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RecruitmentController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private IFormFile formFile;
        public RecruitmentController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var model = _dbContext.Recruitments.ToList();
            return View(model);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Recruitment recruitmentModel, IFormFile ImagePath)
        {
            if (ImagePath != null)
            {
                long size = ImagePath.Length;
                var filePath = Path.Combine("",
                                    "Uploads", "Images", ImagePath.FileName.ToString().Trim('"'));
                formFile = ImagePath;
                if (size > 0)
                {
                    if (ModelState.IsValid)
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                        recruitmentModel.ImagePath = filePath;
                        _dbContext.Add(recruitmentModel);
                        await _dbContext.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            return View(recruitmentModel);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _dbContext.Recruitments.SingleOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Recruitment recruitment, IFormFile ImagePath)
        {
            if (ImagePath != null)
            {
                long size = ImagePath.Length;
                var filePath = Path.Combine("",
                                    "Uploads", "Images", ImagePath.FileName.ToString().Trim('"'));
                formFile = ImagePath;
                if (size > 0)
                {
                    if (ModelState.IsValid)
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                        var model = await _dbContext.Recruitments.SingleOrDefaultAsync(m => m.Id == recruitment.Id);
                        if (model == null)
                        {
                            return NotFound();
                        }
                        model.ImagePath = filePath;
                        await TryUpdateModelAsync<Recruitment>(model);
                        await _dbContext.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(recruitment);
        }
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _dbContext.Recruitments.SingleOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            try
            {
                _dbContext.Recruitments.Remove(model);
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