using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace DoAnSem3.Controllers
{
    public class BaseController : Controller, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("LoginCustomer") == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { Controller = "LoginCustomer", Action = "Index", Areas = "" })
                );
            }
            base.OnActionExecuting(context);
        }
    }
}