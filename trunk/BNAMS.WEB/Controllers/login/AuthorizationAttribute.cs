using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SR.Controllers.login
{
    public class AuthorizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var actionName = filterContext.ActionDescriptor.ActionName;
            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            var objHttpSessionStateBase = filterContext.HttpContext.Session;
            var userSession = objHttpSessionStateBase["userid"];
            if (((userSession != null) || (objHttpSessionStateBase.IsNewSession)) &&
                (!objHttpSessionStateBase.IsNewSession)) return;
            objHttpSessionStateBase.RemoveAll();
            objHttpSessionStateBase.Clear();
            objHttpSessionStateBase.Abandon();
                
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.HttpContext.Response.StatusCode = 403;
                filterContext.Result = new JsonResult { Data = "LogOut" };
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
            }
        }
    }
}