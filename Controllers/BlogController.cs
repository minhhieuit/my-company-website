using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC_Thehegeo.Data;

namespace MVC_Thehegeo.Controllers
{
    public class BlogController : Controller
    {

        // ILogger<ControllerNameController> _logger;

        // public ControllerNameController(ILogger<ControllerNameController> logger)
        // {
        //   _logger = logger;
        // }
        private readonly ApplicationDbContext _dbContext;
        private List<string> listImage;
        public BlogController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> ServiceDetail(int? id)
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
            List<string> listImages = model.ImageLink.Split("|").ToList();
            if(listImages.Count > 0)
            {
                ViewBag.ListImages = listImages;
            }
            else
            {
                listImages.Add(model.ImageLink);
                ViewBag.ListImages = listImages;
            }
            ViewBag.ListService = await _dbContext.ServiceCompanys.ToListAsync();
            return View(model);
        }
        public async Task<IActionResult> ProductDetail(int? id)
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
            ViewBag.ListProduct = await _dbContext.FeaturedWorks.ToListAsync();
            string[] listImages = model.Thumbnail?.Split("|");
            if (listImages?.Length > 0)
            {
                ViewBag.ListImages = listImages;
            }
            else
            {
                listImages?.Append(model.Thumbnail);
                ViewBag.ListImages = listImages;
            }

            return View(model);
        }
        public async Task<IActionResult> RecruitmentDetail(int? id)
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

            ViewBag.ListRecruitment = await _dbContext.Recruitments.ToListAsync();
            return View(model);
        }
    }
}