using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.Web.Models;
using eUseControl.Web.Extensions;
using eUseControl.BusinessLogic.Interfaces;

namespace eUseControl.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IPosts _posts;
        public HomeController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _posts = bl.GetPosts();
        }

        public ActionResult Index()
        {
            SessionStatus();
            var user = System.Web.HttpContext.Current.GetMySessionObject();
            if (user == null)
            {
                return View();
            }
            List<string> PostTitle = _posts.GetPostsList();
            List<string> PostText = _posts.GetPostsList1();
            List<string> PostImage = _posts.GetPostsList2();

            UserData u = new UserData
            {
                Username = user.Username,
                Level = user.Level,
                TitleList = PostTitle,
                TextList = PostText,
                ImageList = PostImage
            };
            return View(u);
        }
    }
}