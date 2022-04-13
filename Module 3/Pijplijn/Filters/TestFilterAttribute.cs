using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Pijplijn.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class TestFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //context.
            //context.HttpContext.Response.
            context.Result = new OkObjectResult("Hahaha");
            return;
           System.Console.WriteLine("Before Executing");
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            System.Console.WriteLine("After Executing");
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            
            System.Console.WriteLine("Before processing Result");
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            System.Console.WriteLine("After processing result");
        }
    }
}