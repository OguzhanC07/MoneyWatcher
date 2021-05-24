using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        public BudgetController(IBudgetService budgetService, IMapper mapper)
        {
            _budgetService = budgetService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBudget(IdModel model)
        {
            var budget=await _budgetService.GetBudgetWithDate(model.Id);
            return Ok(ResponseCreater.CreateResponse(true,"Operation completed successfully",_mapper.Map<BudgetAddDto>(budget)));
        }

        [HttpGet]
        public async Task<IActionResult> GetBudgets()
        {
            var result = _mapper.Map<List<BudgetDetailDto>>(
                await _budgetService.GetThisMonthBudgetsAsync(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))));

            return Ok(ResponseCreater.CreateResponse(true,"Your operation completed successfully",result));
        }
        
        
        
        [HttpPost]
        public async Task<IActionResult> AddBudget(BudgetAddDto budget)
        {
            budget.UserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _budgetService.AddAsync(_mapper.Map<Budget>(budget));
            return Ok(ResponseCreater.CreateResponse(true, "Added successfully", budget));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBudget(BudgetUpdateDto updateDto)
        {
            var findBudget = await _budgetService.GetBudgetWithDate(updateDto.Id);

            findBudget.BudgetDate.IsMonthly = updateDto.BudgetDate.IsMonthly;
            findBudget.BudgetDate.StartDate = updateDto.BudgetDate.StartDate;
            findBudget.BudgetDate.FinishDate = updateDto.BudgetDate.FinishDate;
            findBudget.Detail = updateDto.Detail;
            findBudget.Name = updateDto.Name;
            findBudget.Price = updateDto.Price;
            findBudget.CategoryId = updateDto.CategoryId;
            findBudget.BudgetType = updateDto.BudgetType;

            await _budgetService.UpdateAsync(findBudget);
            return Ok(ResponseCreater.CreateResponse(true, "Update successfully", updateDto));
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteBudget(IdModel deleteModel)
        {
            var findbudget = await _budgetService.GetByIdAsync(deleteModel.Id);
            await _budgetService.DeleteAsync(findbudget);
            return Ok(ResponseCreater.CreateResponse(true, "Delete successfully", null));
        }
    }
}