using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoneyWatcher.Businness.Abstract;
using MoneyWatcher.Businness.Utils.ResponseMessage;
using MoneyWatcher.Entities.Abstract;

namespace MoneyWatcher.Web.CustomFilters
{
    public class ValidId<T,TId>: IActionFilter where T : class,IEntity,new()
    where TId:new()
    {
        private readonly IGenericService<T,TId> _genericService;

        public ValidId(IGenericService<T,TId> genericService)
        {
            _genericService = genericService;
        }
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var list = context.ActionArguments.ToList();

            var dictionary = context.ActionArguments.FirstOrDefault(I => I.Key == "id");
            var id = (TId) dictionary.Value;

            var entity = _genericService.GetByIdAsync(id);

            if (entity == null)
                context.Result =
                    new OkObjectResult(ResponseCreater.CreateResponse(false, "The requested item not found", null));
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}