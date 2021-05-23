using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public async Task<IActionResult> UpdateBudget(BudgetUpdateDto updateDto)
        {
            var findBudget = await _budgetService.GetBudgetWithDate(updateDto.Id);

            findBudget.BudgetDate.IsMonthly= updateDto.BudgetDate.IsMontly;
            findBudget.BudgetDate.StartDate = updateDto.BudgetDate.StartDate;
            findBudget.BudgetDate.FinishDate = updateDto.BudgetDate.FinishDate;
            findBudget.Detail = updateDto.Detail;
            findBudget.Name = updateDto.Name;
            findBudget.Price = updateDto.Price;
            findBudget.CategoryId = updateDto.CategoryId;
            findBudget.BudgetType = updateDto.BudgetType;
            
            await _budgetService.UpdateAsync(findBudget);
            return Ok(ResponseCreater.CreateResponse(true,"Delete successfully",updateDto));
        }

      [HttpDelete]
      public async Task<IActionResult> DeleteBudget(DeleteModel deleteModel)
        {
            var findbudget = await _budgetService.GetByIdAsync(deleteModel.Id);
            await _budgetService.DeleteAsync(findbudget);            
            return Ok(ResponseCreater.CreateResponse(true, "Delete successfully", null ));
        }
    }
}