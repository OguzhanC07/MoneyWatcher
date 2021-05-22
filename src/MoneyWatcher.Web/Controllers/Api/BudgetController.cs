using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoneyWatcher.Businness.Abstract;
using MoneyWatcher.Businness.Utils.Dtos.BudgetDto;
using MoneyWatcher.Businness.Utils.ResponseMessage;
using MoneyWatcher.Entities.Concrete;
using MoneyWatcher.Web.Models;

namespace MoneyWatcher.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _budgetService;
        private readonly IMapper _mapper;
        public BudgetController(IBudgetService budgetService,IMapper mapper)
        {
            _budgetService = budgetService;
            _mapper = mapper;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddBudget(Budget budget)
        {
            await _budgetService.AddAsync(budget);
            return Ok(ResponseCreater.CreateResponse(true,"Added successfully", budget));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBudget(BudgetUpdateDto budget)
        {
            var findBudget = await _budgetService.GetByIdAsync(budget.Id);
            findBudget.BudgetDate = _mapper.Map<BudgetDate>(budget.BudgetDate);
            await _budgetService.UpdateAsync(findBudget);
            return Ok(ResponseCreater.CreateResponse(true, "Update successfully", budget));
        }
        //_mapper.Map<Budget>(budget)

      [HttpDelete]
      public async Task<IActionResult> DeleteBudget(DeleteModel deleteModel)
        {
            var findbudget = await _budgetService.GetByIdAsync(deleteModel.Id);
            await _budgetService.DeleteAsync(findbudget);            
            return Ok(ResponseCreater.CreateResponse(true, "Delete successfully", null ));
        }
    }
}