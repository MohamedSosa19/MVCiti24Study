using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCiti24.ViewModels;

namespace MVCiti24.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult AddRole()
        {
            return View("AddRole");
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel RoleVM)
        {
            if(ModelState.IsValid)
            {
                IdentityRole role =new IdentityRole()
                {
                    Name=RoleVM.RoleName
                };
                IdentityResult result = await _roleManager.CreateAsync(role);

                if(result.Succeeded)
                {
                    ViewBag.sucess = true;
                    return View("AddRole");
                }
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("AddRole",RoleVM);

        }
    }
}
