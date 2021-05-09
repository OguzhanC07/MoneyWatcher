using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoneyWatcher.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            //budgetlar getirildi
            return Ok(new {Budget = "Budget1", Price = "120"});
        }
    }
}