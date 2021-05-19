using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MoneyWatcher.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        public IActionResult AddBudget()
        {
            return Ok();
        }
    }
}