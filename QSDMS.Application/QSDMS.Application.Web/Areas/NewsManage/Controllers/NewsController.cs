using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QSDMS.Application.Web.Areas.NewsManage.Controllers
{
    public class NewsController : Controller
    {
        //
        // GET: /NewsManage/News/

        public ActionResult Index()
        {
            return View();
        }

    }
}
