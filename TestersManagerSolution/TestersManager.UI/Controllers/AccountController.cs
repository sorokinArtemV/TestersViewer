using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestersManager.Core.Domain.IdentityEntities;
using TestersManager.Core.DTO;

namespace TestersManager.UI.Controllers;

[Route("[controller]/[action]")]
public class AccountController : Controller
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;


    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }


    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        // TODO does not work for password
        if (!ModelState.IsValid)
        {
            ViewBag.Errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            return View(registerDto);
        }

        ApplicationUser user = new()
        {
            UserName = registerDto.Email,
            Email = registerDto.Email,
            TesterName = registerDto.TesterName
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (result.Succeeded)
        {
            // Sign in
            await _signInManager.SignInAsync(user, false); // can create checkbox in front for this

            return RedirectToAction(nameof(TestersController.Index), "Testers");
        }

        foreach (var error in result.Errors) ModelState.AddModelError("Register", error.Description);

        // temp solution
        ViewBag.Errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();

        return View(registerDto);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        // TODO does not work
        if (!ModelState.IsValid)
        {
            ViewBag.Errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            return View(loginDto);
        }

        var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, false, false);

        if (result.Succeeded)
        {
            return RedirectToAction(nameof(TestersController.Index), "Testers");
        }
        
        ModelState.AddModelError("Login", "Invalid email or password");
        
        // temp solution
        ViewBag.Errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
        
        return View(loginDto);
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        
        return RedirectToAction(nameof(TestersController.Index), "Testers");
    }
}