using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyWatcher.Businness.Abstract;
using MoneyWatcher.Businness.Utils.Dtos.BudgetDateDto;
using MoneyWatcher.Businness.Utils.Dtos.BudgetDto;
using MoneyWatcher.Businness.Utils.ResponseMessage;
using MoneyWatcher.Entities.Concrete;
using MoneyWatcher.Web.CustomFilters;
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
            return Ok(ResponseCreater.CreateResponse(true,"Operation completed successfully",_mapper.Map<BudgetDetailDto>(budget)));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetThisYearMonthlyData()
        {
            var budget = await _budgetService.GetSelectedYearMonthlyDataAsnyc(new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            return Ok(ResponseCreater.CreateResponse(true,"Your operation completed",budget));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetBudgets()
        {
            var result = _mapper.Map<List<BudgetDetailDto>>(
                await _budgetService.GetSelectedDateBudgetsAsync(
                    new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))
                    ,DateTime.Now.Month
                    ,DateTime.Now.Year));

            return Ok(ResponseCreater.CreateResponse(true,"Your operation completed successfully",result));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBudgetsWithDate([FromQuery] DateDto date)
        {
            var result = _mapper.Map<List<BudgetDetailDto>>(
                await _budgetService.GetSelectedDateBudgetsAsync(
                    new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier))
                    ,date.MonthNum
                    ,date.YearNum));
            return Ok(ResponseCreater.CreateResponse(true, "Your operation completed successfully", result));
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
            var updatedBudget = _mapper.Map(updateDto, findBudget);
            await _budgetService.UpdateAsync(updatedBudget);
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