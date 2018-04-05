using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Thehegeo.Data;
using MVC_Thehegeo.Models.BlogModels;

namespace MVC_Thehegeo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PartnerController : Controller
    {
        IFormFile formFile;
        public ApplicationDbContext _dbContext;
        public PartnerController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _dbContext.Partners.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Partner partner, IFormFile Image)
        {
            if (Image != null)
            {
                long size = Image.Length;
                var filePath = Path.Combine("",
                                    "Uploads", "Images", Image.FileName.ToString().Trim('"'));
                formFile = Image;
                if (size > 0)
                {
                    if (ModelState.IsValid)
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                        partner.Image = filePath;
                        _dbContext.Add(partner);
                        await _dbContext.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }

            }

            return View(partner);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _dbContext.Partners.SingleOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,Company,ContentVI,ContentEN,Image")] Partner partner, IFormFile Image)
        {
            if (Image != null)
            {
                long size = Image.Length;
                var filePath = Path.Combine("", "Uploads", "Images", Image.FileName.ToString().Trim('"'));
                formFile = Image;
                if (size > 0)
                {
                    if (ModelState.IsValid)
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                        var model = await _dbContext.Partners.SingleOrDefaultAsync(m => m.Id == partner.Id);
                        model.Image = filePath;
                        await TryUpdateModelAsync<Partner>(model, "", m => m.Company, m => m.ContentVI, m => m.ContentEN, m => m.Image);
                        _dbContext.SaveChanges();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(partner);
        }
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _dbContext.Partners.SingleOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            try
            {
                _dbContext.Partners.Remove(model);
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