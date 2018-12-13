using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QSDMS.Application.Web.Areas.WebSite.Controllers
{
    public class CommController : BaseController
    {
        public ActionResult Header()
        {
            return View();
        }
        //
        // GET: /Comm/
        public ActionResult Footer()
        {
            return View();
        }
    }
}