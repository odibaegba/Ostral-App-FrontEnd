using Microsoft.AspNetCore.Mvc;
using Ostral.Core.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Ostral.Core.ViewModel;

namespace Ostral.WEB.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }
        
        [HttpGet("login")]
        public IActionResult Login(string returnUrl = "")
        {
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.LoginErrMsg = false;

            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm]LoginVM model, string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.LoginErrMsg = false;

            if (!ModelState.IsValid)
            {
                ViewBag.LoginErrMsg = true;
                return View(model);
            }

            var loginResponse = await _authService.Login(model);
            if (!loginResponse.Status || loginResponse.Data!.Token == null)
            {
                ViewBag.LoginErrMsg = true;
                foreach (var error in loginResponse.Errors)
                {
                    ModelState.AddModelError(error, error);
                }
                return View(model);
            }

            await LoginUser(loginResponse.Data.Token);

            _logger.LogInformation("User logged in successfully");
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet("register")]
        public ViewResult Register()
        {
            ViewBag.RegisterErrMsg = false;
            
            return View();
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.RegisterErrMsg = true;
                return View(model);
            }

            var registerResponse = await _authService.Register(model);
            if (!registerResponse.Status || registerResponse.Data!.Token == null)
            {
                ViewBag.LoginErrMsg = true;
                foreach (var error in registerResponse.Errors)
                {
                    ModelState.AddModelError(error, error);
                }
                return View(model);
            }

            await LoginUser(registerResponse.Data.Token);

            _logger.LogInformation("User registered successfully");
            return RedirectToAction("Index", "Dashboard");
        }
        
        // [HttpGet("register-tutor")]
        // public ViewResult RegisterTutor()
        // {
        //     return View();
        // }
        
        // [AllowAnonymous]
        // [HttpPost("register-tutor")]
        // public async Task<IActionResult> RegisterTutor(RegisterVM user)
        // {
        //     if (!ModelState.IsValid) return View(user);
        //
        //
        //     if (user.Equals(UserRole.Student))
        //     {
        //         await _authService.RegisterStudentAsync(user);
        //         RedirectToAction("EmailConfirmation", "Auth");
        //     }
        //
        //
        //     else if (user.Equals(UserRole.Tutor))
        //     {
        //         await _authService.RegisterTutorAsync(user);
        //         RedirectToAction("TutorDetailsPage", "Auth");
        //     }
        //
        //     return View(user);
        // }

        // public ViewResult TutorDetailsPage()
        // {
        //     return View();
        // }

        [Authorize]
        [HttpGet("confirm-email")]
        public ViewResult EmailConfirmation()
        {
            return View();
        }

        public async Task<IActionResult> LogoutAsync()
        {
            //TODO: call the signout backend endpoint before deleting cookie
            
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            
            return RedirectToAction("Index", "Home");
        }

        private async Task LoginUser(string userToken)
        {
            var tokenValues = new JwtSecurityTokenHandler().ReadJwtToken(userToken);
            var claims = new List<Claim>
            {
                new("jwt", userToken),
            };

            claims.AddRange(tokenValues.Claims);
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}