﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolioProjectNigth.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult CategoryList()
        {
            return View();
        }
        public ActionResult CreateCategory() 
        {
            return View();
        }
    }
}