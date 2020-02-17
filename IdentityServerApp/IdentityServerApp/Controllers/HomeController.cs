using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServerApp.Controllers
{
    public class HomeController : Controller
    { 
        public IActionResult Index()
        {
            return View();
        } 

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        } 
        
        public IActionResult Authenticate()
        {

            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Kunal"),
                new Claim(ClaimTypes.Email,"kunaldubey2297@gmail.com"), 
                new Claim("RollNumber", "16P61A1206")
            };

            var companyClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Technovert"),
                new Claim("Employee Id", "IT 129")
            };

            var authIdentity = new ClaimsIdentity(authClaims, "Authentication Claims");
            var companyIdentity = new ClaimsIdentity(companyClaims, "Company Claims");

            var userPrincipal = new ClaimsPrincipal(new[] { authIdentity, companyIdentity });
            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index");
        }
    }
}
