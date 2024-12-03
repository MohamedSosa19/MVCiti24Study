using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVCiti24.Models;
using MVCiti24.ViewModels;

namespace MVCiti24.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
                                  SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
       
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        
        public async Task<IActionResult> Register(RegisterUserViewModel userVM)
        {
            if(ModelState.IsValid)
            {
                //found
                ApplicationUser appUser = new ApplicationUser() { 

                    UserName = userVM.UserName,
                    Address = userVM.Address,
                    PasswordHash=userVM.Password
                };

                IdentityResult result=await _userManager.CreateAsync(appUser,userVM.Password);
                if (result.Succeeded)
                {
                    //Assign To role
                    await _userManager.AddToRoleAsync(appUser, "Admin");                   
                    //save Cookies
                    await _signInManager.SignInAsync(appUser,false);
                }
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);
                }
            }
            return View("Register", userVM);
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return View("Register");
        }

        public IActionResult Login()
        {
            return View("Login");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel loginVM)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser appUser= await _userManager.FindByNameAsync(loginVM.UserName);
                if(appUser != null)
                {
                    bool found = await _userManager.CheckPasswordAsync(appUser, loginVM.Password);
                    if (found)
                    {
                        await _signInManager.SignInAsync(appUser, loginVM.RememberMe);
                        return RedirectToAction("ShowAll", "Products");
                    }
                }
                ModelState.AddModelError("", "UserName or Password Wrong");
            }
            return View("Login",loginVM);
        }
    }
}
