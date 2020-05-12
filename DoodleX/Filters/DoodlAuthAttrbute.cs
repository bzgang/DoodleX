using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Routing;

namespace DoodleX.Filters
{
    public class DoodlAuthAttrbute : AuthorizeAttribute, IActionFilter//,ActionFilterAttribute //(继承了ActionFilterAttribute : FilterAttribute, IActionFilter, IResultFilter)
    {
        static string logStr = "";
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            logStr += "<2>---------------\r\n";
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            logStr += "<1>-2323232--------------\r\n";
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return false;
        }


        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //HttpActionContext actionContext = new HttpActionContext();
            //actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Count;
            var aaa = filterContext.ActionDescriptor.GetCustomAttributes(true);

            Object[] actionFilter = filterContext.ActionDescriptor.GetCustomAttributes(
                typeof(AllowAnonymousAttribute), false);
            //有 NoAuthentication 则 不验证
            if (actionFilter.Length > 0)
            {
                return;
            }


            if (filterContext.HttpContext.Session["loginUser"] == null)
            {
                filterContext.HttpContext.Session.Add("loginUser", "当前登陆人1");

                filterContext.Result = new RedirectToRouteResult("Default", new RouteValueDictionary()
                {
                    {"controller","home" },
                    {"action","NoLogin" }
                });
                //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary()
                //{   
                //    {"controller","home" },
                //    {"action","NoLogin" }
                //});
            }
            else
            {
                filterContext.HttpContext.Session["loginUser"].ToString();

            }
            string ab = filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(true).ToString();
            string currentActionName = filterContext.ActionDescriptor.ActionName;
            string currentControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string a = filterContext.HttpContext.Request.Url + currentControllerName + "/" + currentActionName;

            logStr += "<0>" + a + "\r\n";

        }
    }

    public class DoodExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
}