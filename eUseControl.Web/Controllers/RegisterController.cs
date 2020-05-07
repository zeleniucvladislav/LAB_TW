using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Web.Models;


namespace eUseControl.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegister _session;
        public RegisterController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetRegisterBL();
        }
        // GET: Regin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserRegister register)
        {
            if (ModelState.IsValid)
            {
                UsersDbTable data = new UsersDbTable
                {
                    Username = register.Username,
                    Password = register.Password,
                    Email = register.Email,
                    RegisterDate = DateTime.Now
                };

                var userLogin = _session.UserRegisterAction(data);
                if (userLogin.Status)
                {
                    //ADD COOKIE

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userLogin.StatusMsg);
                    return View();
                }

            }

            return View();
        }
    }
}