using System;
using eUseControl.Domain.Entities.User;
using eUseControl.Web.App_Start;
using eUseControl.Web.Extensions;
using eUseControl.Web.Models;
using System.Web.Mvc;
using eUseControl.BusinessLogic.Interfaces;
using AutoMapper;
using eUseControl.Domain.Entities.Posts;

namespace eUseControl.Web.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IPosts _posts;
        public AdminController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _posts = bl.GetPosts();
        }
        [AdminMode]
        public ActionResult Index(UserData post)
        {
            SessionStatus();
            var user = System.Web.HttpContext.Current.GetMySessionObject();
            if (user == null)
            {
                return View();
            }

            UserData u = new UserData
            {
                Username = user.Username,
                Level = user.Level
            };
            if (ModelState.IsValid)
            {
                PostsTable data = new PostsTable
                {
                    Title = post.Title,
                    Text = post.Text,
                    Image = post.Image,
                };

                var userLogin = _posts.SetPostsList(data);
                if (userLogin.Status)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userLogin.StatusMsg);
                    return View();
                }

            }


            return View(u);
        }
    }
}