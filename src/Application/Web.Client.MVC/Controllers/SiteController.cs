using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Web.Client.MVC.Controllers
{
    [Route("[controller]")]
    public class SiteController : Controller
    {
        [HttpGet]
        [Route("[action]")]
        public IActionResult Index()
        {
            var isAuth = HttpContext.User.Identity?.IsAuthenticated;

            return View();
        }

        [Authorize]
        [Route("[action]")]
        public async Task<IActionResult> Secret()
        {
            
            var jsonToken = await HttpContext.GetTokenAsync("access_token");
            var idToken = HttpContext.GetTokenAsync("id_token").GetAwaiter().GetResult();
            var token = new JwtSecurityTokenHandler().ReadJwtToken(jsonToken);
            var res = token.Subject;
            return View();
        }
    }
}
