using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC_Thehegeo.Data;
using MVC_Thehegeo.Models.BlogModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace MVC_Thehegeo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public PostController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var model = _dbContext.Posts
            .Include(p => p.User)
            .Include(p => p.Category)
            .ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var listUsers = _dbContext.Users.ToList();
            var categories = _dbContext.Categories.ToList();
            ViewBag.ListUsers = listUsers;
            ViewBag.ListCategories = categories;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title,CategoryId,Content,Image,UserId")] Post model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(model);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var listUsers = _dbContext.Users.ToList();
            var categories = _dbContext.Categories.ToList();
            ViewBag.ListUsers = listUsers;
            ViewBag.ListCategories = categories;
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = await _dbContext.Posts.SingleOrDefaultAsync(m => m.Id == id);
            await TryUpdateModelAsync<Post>(post);
            if (post == null)
            {
                return NotFound();
            }
            var listUsers = _dbContext.Users.ToList();
            var categories = _dbContext.Categories.ToList();
            ViewBag.ListUsers = listUsers;
            ViewBag.ListCategories = categories;
            return View(post);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Title,CategoryId,Content,Image,UserId")] Post post)
        {
            if (ModelState.IsValid)
            {
                var model = await _dbContext.Posts.SingleOrDefaultAsync(m => m.Id == post.Id);
                await TryUpdateModelAsync<Post>(model, "", m => m.Title, m => m.CategoryId, m => m.Content, m => m.Image, m => m.UserId);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            var listUsers = _dbContext.Users.ToList();
            var categories = _dbContext.Categories.ToList();
            ViewBag.ListUsers = listUsers;
            ViewBag.ListCategories = categories;
            return View(post);
        }
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _dbContext.Posts.SingleOrDefaultAsync(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            try
            {
                _dbContext.Posts.Remove(model);
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