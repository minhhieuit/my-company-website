using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC_Thehegeo.Data;
using MVC_Thehegeo.Models.BlogModels;

namespace MVC_Thehegeo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ServiceCompanyController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private IFormFile formFile;
        public ServiceCompanyController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var model = _dbContext.ServiceCompanys.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ServiceCompany serviceCompany, List<IFormFile> ImageLink)
        {
            if (ImageLink?.Count > 0)
            {
                foreach (var item in ImageLink)
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
                            serviceCompany.ImageLink += filePath + "|";
                        }
                    }
                }
                _dbContext.Add(serviceCompany);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(serviceCompany);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _dbContext.ServiceCompanys.SingleOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ServiceCompany serviceCompany, List<IFormFile> ImageLink)
        {
            var model = await _dbContext.ServiceCompanys.SingleOrDefaultAsync(m => m.Id == serviceCompany.Id);
            if (model == null)
            {
                return NotFound();
            }
            if (ImageLink != null)
            {
                foreach (var item in ImageLink)
                {
                    var filePath = Path.Combine("",
                                    "Uploads", "Images", item.FileName.ToString().Trim('"'));
                    if (item.Length > 0)
                    {
                        if (ModelState.IsValid)
                        {
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await item.CopyToAsync(stream);
                            }
                            model.ImageLink += filePath + "|";
                        }
                    }
                }
                await TryUpdateModelAsync<ServiceCompany>(model, "", m => m.Id, m => m.TitleVI, m => m.TitleEN, m => m.ContentVI, m => m.ContentEN, m => m.Icon, m => m.ImageLink, m => m.IntroVI, m => m.IntroEN);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(serviceCompany);
        }
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _dbContext.ServiceCompanys.SingleOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            try
            {
                _dbContext.ServiceCompanys.Remove(model);
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