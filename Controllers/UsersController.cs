using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HerramientasProgFinal.Models;
using Microsoft.AspNetCore.Identity;
using HerramientasProgFinal.Services;
using HerramientasProgFinal.Views.Users.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
namespace HerramientasProgFinal.Controllers;

public class UsersController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UsersController(
        ILogger<HomeController> logger,
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    [Authorize(Roles = "AdminSupremo,SemiAdmin")]
    public IActionResult Index()
    {
        //listar todos los usuarios
        var users = _userManager.Users.ToList();
        return View(users);
    }

    [Authorize(Roles = "AdminSupremo,SemiAdmin")]
    public async Task<IActionResult> Edit(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        var userViewModel = new UserEditViewModel();
        userViewModel.UserName = user.UserName ?? string.Empty;
        userViewModel.Email = user.Email ?? string.Empty;
        userViewModel.Roles = new SelectList(_roleManager.Roles.ToList());

        return View(userViewModel);
    }

    [HttpPost]
    [Authorize(Roles = "AdminSupremo,SemiAdmin")]
    public async Task<IActionResult> Edit(UserEditViewModel model)
    {
        var user = await _userManager.FindByNameAsync(model.UserName);

        if (user != null)
        {
            if (model.Role == null)
            {
                Console.WriteLine("model.Role is null");
            }

            await _userManager.AddToRoleAsync(user, model.Role);
        }
        else
        {
            Console.WriteLine("user is null");
        }

        var roles = await _userManager.GetRolesAsync(user);


        return RedirectToAction("Index");
    }

}