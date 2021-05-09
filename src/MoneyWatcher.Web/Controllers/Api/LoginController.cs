using Microsoft.AspNetCore.Mvc;

namespace MoneyWatcher.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public IActionResult Login()
        {
            return Ok(new {Ahmet="123",Number=123});
        }
        
        [HttpGet("[action]")]
        public IActionResult Register()
        {
            return Ok(new {Ahmet="Register",Number=123});
        }
    }
}