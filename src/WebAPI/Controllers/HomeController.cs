using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public string Index()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(e => e.Type == "sub").Value;
            return userId;
        }
        //[HttpGet]
        //[Authorize]
        ////[Route("[action]")]
        //public async Task<IActionResult> Secret()
        //{
        //    var contex = await HttpContext.GetTokenAsync("access_token");
        //    return View();
        //}


    }
}
