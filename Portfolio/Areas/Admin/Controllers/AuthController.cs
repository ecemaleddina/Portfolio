using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserDTO userDTO)
        {
            var checkUsername = await _userManager.FindByNameAsync(userDTO.Username);
            if (checkUsername is not null)
            {
                var result = await _signInManager.PasswordSignInAsync(checkUsername, userDTO.Password, true, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Default"); 
                }
                else
                {
                    return Redirect("Index");
                }
            }
            else
            {
                return Redirect("Index");
            }
        }
    }
}
