using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Thehegeo.Models;
using MVC_Thehegeo.Models.ManageViewModels;

namespace mvc.Areas.Admin.Controllers
{
  [Authorize]
  [Area("Admin")]
  public class HomeController : Controller
  {

    ILogger<HomeController> _logger;
    private readonly UserManager<ApplicationUser> _userManager;
    public HomeController(ILogger<HomeController> logger,UserManager<ApplicationUser> userManager)
    {
      _logger = logger;
       _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        }

        var model = new IndexViewModel
        {
            Username = user.UserName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            IsEmailConfirmed = user.EmailConfirmed,
            StatusMessage = StatusMessage
        };

        return View(model);
    }
    [TempData]
    public string StatusMessage { get; set; }

  }
}