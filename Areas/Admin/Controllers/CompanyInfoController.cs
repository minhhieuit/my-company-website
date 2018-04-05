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
    public class CompanyInfoController : Controller
    {

        public ApplicationDbContext _dbContext;
        public CompanyInfoController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var model = _dbContext.CompanyInfos.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Phone,Email,AddressEN,AddressVI,GooglePlusLink,TwitterLink,FacebookLink,YoutubeLink")] CompanyInfo companyInfo)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(companyInfo);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyInfo);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _dbContext.CompanyInfos.SingleOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,Name,Phone,Email,AddressEN,AddressVI,GooglePlusLink,TwitterLink,FacebookLink,YoutubeLink")] CompanyInfo companyInfo)
        {
            if (ModelState.IsValid)
            {
                var company = await _dbContext.CompanyInfos.SingleOrDefaultAsync(m => m.Id == companyInfo.Id);
                await TryUpdateModelAsync<CompanyInfo>(company);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(companyInfo);
        }
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _dbContext.CompanyInfos.SingleOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            try
            {
                _dbContext.CompanyInfos.Remove(model);
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