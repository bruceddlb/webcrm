﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QSDMS.WebSite.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            //string aa = CurrentLanguge.LanguageDesc;
            return View();
        }
    }
}