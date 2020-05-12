﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: NotFound
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}