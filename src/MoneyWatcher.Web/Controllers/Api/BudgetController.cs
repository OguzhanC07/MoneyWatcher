using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyWatcher.Businness.Abstract;
using MoneyWatcher.Businness.Utils.ResponseMessage;
using MoneyWatcher.Entities.Concrete;

namespace MoneyWatcher.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _budgetService;
        public BudgetController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddBudget(Budget budget)
        {
            await _budgetService.AddAsync(budget);
            return Ok(ResponseCreater.CreateResponse(true,"Added successfully", budget));
        }
    }
}