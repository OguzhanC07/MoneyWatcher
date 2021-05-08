using Microsoft.AspNetCore.Mvc;

namespace MoneyWatcher.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Created("",new{api="123",view="a"});
        }
    }
}