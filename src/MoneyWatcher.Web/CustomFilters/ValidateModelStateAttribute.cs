using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoneyWatcher.Businness.Utils.ResponseMessage;

namespace MoneyWatcher.Web.CustomFilters
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid) return;
            var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                .SelectMany(v => v.Errors)
                .Select(v => v.ErrorMessage)
                .ToList();
            context.Result= new OkObjectResult(ResponseCreater.CreateResponse(false, "One or more error occured", errors));
        }
    }
}