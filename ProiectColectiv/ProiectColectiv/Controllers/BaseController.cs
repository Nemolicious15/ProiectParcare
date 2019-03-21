using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProiectColectiv.Controllers
{
    public class BaseController : Controller
    {
        
        protected override void OnActionExecuting(ActionExecutingContext context)
        {
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            if (Session["UserId"]==null && controllerName != "Account" && (actionName!="Login" || actionName!="Create"))
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"controller", "Account"},
                        {"action", "Login"}
                    }
                );
            }
            base.OnActionExecuting(context);
        }
    }
}