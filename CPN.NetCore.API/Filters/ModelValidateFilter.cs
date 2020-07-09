using CPN.NetCore.DTO.Core.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPN.NetCore.API.Filters
{
    public class ModelValidateFilter : IActionFilter
    {
       
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ResponseDTO<ModelStateDictionary> validateErrorModel = new ResponseDTO<ModelStateDictionary>(true, "Model Validation Error", context.ModelState);

                context.Result = new BadRequestObjectResult(validateErrorModel);
            }
        }
    }
}
