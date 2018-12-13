using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteCMS.Business;
using WebSiteCMS.Model;
using QSDMS.Util;
namespace QSDMS.Application.Web.Areas.WebSite.Controllers
{
    public class JobController : BaseController
    {
        //
        // GET: /WebSite/Job/

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetJobList()
        {
            JobEntity para = new JobEntity();
            para.LanguageKey = CurrentLanguge.LanguageKey;
            var list = JobBLL.Instance.GetList(para);

            return Content(list.ToJson());
        }

    }
}
