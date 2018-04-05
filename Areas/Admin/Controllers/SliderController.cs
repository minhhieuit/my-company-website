using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MVC_Thehegeo.Data;
using Microsoft.EntityFrameworkCore;
using MVC_Thehegeo.Models.BlogModels;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace MVC_Thehegeo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SliderController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private IFormFile _formFile;
        public SliderController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _dbContext.Sliders.ToListAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title,Description,ImageLink")]SliderModel sliderModel, IFormFile ImageLink)
        {
            if (ImageLink != null)
            {
                long size = ImageLink.Length;
                var filePath = Path.Combine("",
                                    "Uploads", "Images", ImageLink.FileName.ToString().Trim('"'));
                _formFile = ImageLink;
                if (size > 0)
                {
                    if (ModelState.IsValid)
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await _formFile.CopyToAsync(stream);
                        }
                        sliderModel.ImageLink = filePath;
                        _dbContext.Add(sliderModel);
                        await _dbContext.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(sliderModel);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _dbContext.Sliders.SingleOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,Title,Description,ImageLink")] SliderModel sliderModel)
        {
            if (ModelState.IsValid)
            {
                var model = await _dbContext.Sliders.SingleOrDefaultAsync(m => m.Id == sliderModel.Id);
                await TryUpdateModelAsync<SliderModel>(model, "", m => m.Id, m => m.Title, m => m.Description, m => m.ImageLink);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(sliderModel);
        }
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _dbContext.Sliders.SingleOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            try
            {
                _dbContext.Sliders.Remove(model);
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