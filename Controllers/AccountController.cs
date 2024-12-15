using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

public class AccountController : Controller
{
    private readonly SignInManager<Account> _signinManager;
    private readonly UserManager<Account> _userManager;

    public AccountController(SignInManager<Account> signInManager, UserManager<Account> userManager)
    {
        _signinManager = signInManager;
        _userManager = userManager;
    }


    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(AccountViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = new Teacher
        {
            UserName = model.Email,
            Email = model.Email,
            Firstname = model.Firstname,
            Lastname = model.Lastname,
            Major = model.Major,
            UserType = model.UserType
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            await _signinManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await _signinManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public IActionResult IndexAccount()
    {
        return View();
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }


    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Aucun utilisateur trouvé avec cet email.");
            return View(model);
        }

        var result = await _signinManager.PasswordSignInAsync(user.UserName, model.Password, false, false);

        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }


        if (result.IsLockedOut)
        {
            ModelState.AddModelError(string.Empty, "Votre compte est verrouillé. Veuillez réessayer plus tard.");
        }
        else if (result.IsNotAllowed)
        {
            ModelState.AddModelError(string.Empty, "La connexion n'est pas autorisée. Veuillez vérifier votre compte.");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Email ou mot de passe incorrect.");
        }

        return View(model);
    }

}