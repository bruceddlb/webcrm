using QSDMS.Util.WebControl;
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
    public class DefaultController : BaseController
    {
        public ActionResult Index()
        {            
            //string aa = CurrentLanguge.LanguageDesc;
            return View();
        }

        [HttpGet]
        public ActionResult GetBanner()
        {
            Pagination pagination = new Pagination();
            pagination.rows = 6;
            pagination.page = 1;
            BannerEntity para = new BannerEntity();

            var pageList = BannerBLL.Instance.GetPageList(null, ref pagination);

            return Content(pageList.ToJson());
        }
    }
}