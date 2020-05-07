using System;
using eUseControl.Domain.Entities.User;
using eUseControl.Web.App_Start;
using eUseControl.Web.Extensions;
using eUseControl.Web.Models;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class AdminController : BaseController
    {
        [AdminMode]
        public ActionResult Index()
        {
            SessionStatus();

            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] == "login")
            {
                UserMinimal user = System.Web.HttpContext.Current.GetMySessionObject();
                return View();
            }

            return View();
        }
    }
}