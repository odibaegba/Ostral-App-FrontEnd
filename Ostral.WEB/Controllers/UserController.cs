
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ostral.Core.Interfaces;
using Ostral.Core.ViewModel;
using System.Diagnostics;

namespace Ostral.WEB.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        // private readonly SignInManager<LoginVM> _signInManager;
        // private readonly IUserAuthService _userAuthService;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            // _signInManager = signInManager;
            // _userAuthService = userAuthService;
        }

        public IActionResult Profile()
        {

            return View();
        }
        
        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<IActionResult> Login(string returnUrl)
        //{
        //    LoginVM model = new LoginVM
        //    {
        //        ReturnUrl = returnUrl,
        //        ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
        //    };

        //    return View(model);
        //}

        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult ExternalLogin(string provider, string returnUrl)
        //{
        //    var result = _userAuthService.ExternalLogin();

        //    return View(result);
        //}
    }
}