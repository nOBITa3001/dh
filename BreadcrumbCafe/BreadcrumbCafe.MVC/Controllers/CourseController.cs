﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BreadcrumbCafe.MVC.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index(int id)
        {
            return View();
        }
    }
}