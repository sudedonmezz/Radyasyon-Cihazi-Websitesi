using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZSStore.Models;

namespace ZSStore.Controllers
{
    public class AccountController:Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

       
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
public IActionResult Login(string? returnUrl = "/")
{
    return View(new LoginModel { Returnurl = returnUrl });
}

        [HttpPost]
        [ValidateAntiForgeryToken]
         public async Task<IActionResult> Login([FromForm] LoginModel model) //asenkron çalışır!! task ile sarmalama işlemi
        {
            if(ModelState.IsValid)
            {
                IdentityUser user=await _userManager.FindByEmailAsync(model.Email);
                if(user is not null)
                {
                    //oturum açma işlemi session bilgileri içerir!! signInManager

                    await _signInManager.SignOutAsync();

                    if((await _signInManager.PasswordSignInAsync(user,model.Password,false,false)).Succeeded)
                    {
                        return Redirect(model?.Returnurl ?? "/");
                    }
                }
                ModelState.AddModelError("Hata!","Geçersiz email veya şifre girdiniz.");
            }
            return View();
        }
        public async Task<IActionResult> Logout([FromQuery(Name ="Returnurl")]string Returnurl="/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(Returnurl);
        }

        public IActionResult Register()
    {
        return View();
    }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm]RegisterDto model)
        {
            var user=new IdentityUser
            {
                UserName=model.Email,
                Email=model.Email


            };
            var result= await _userManager.CreateAsync(user,model.Password);
            if(result.Succeeded)
            {
                var roleResult= await _userManager
                .AddToRoleAsync(user,"User");

                if(roleResult.Succeeded)
                {
                    return RedirectToAction("Login");
                }
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);
                }
            }
            return View();
        }

        public IActionResult AccessDenied([FromQuery(Name ="Returnurl")] string returnUrl)
        {
            return View();
        }
    }
    
}