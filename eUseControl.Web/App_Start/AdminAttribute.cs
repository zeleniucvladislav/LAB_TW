using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Enums;
using eUseControl.Web.Extensions;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eUseControl.Web.App_Start
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class NoDirectAccessAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.Url != null && (filterContext.HttpContext.Request.UrlReferrer == null
                || filterContext.HttpContext.Request.UrlReferrer.Host != filterContext.HttpContext.Request.UrlReferrer.Host))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "Error" }));
            }
        }
    }

    public class AdminModeAttribute : ActionFilterAttribute
    {
        private readonly ISession _sessionBusinessLogic;

        public AdminModeAttribute()
        {
            var businessLogic = new BusinessLogic.BusinessLogic();
            _sessionBusinessLogic = businessLogic.GetSessionBL();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var adminSession = HttpContext.Current.GetMySessionObject();
            if (adminSession != null)
            {
                var cookie = HttpContext.Current.Request.Cookies["X-KEY"]; ;
                if (cookie != null)
                {
                    var profile = _sessionBusinessLogic.GetUserByCookie(cookie.Value);
                    if (profile != null && profile.Level == URole.Admin)
                    {
                        HttpContext.Current.SetMySessionObject(profile);
                    }
                    else
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "NotFound" }));
                    }
                }
            }
            else
            {
                if (adminSession.Level != URole.Admin)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "NotFound" }));
                }

            }
        }

    }
}