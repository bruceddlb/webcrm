using iFramework.Framework;
using QSDMS.Application.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteCMS.Business;
using WebSiteCMS.Model;
using QSDMS.Util.Extension;
using QSDMS.Util;
using QSDMS.Util.Attributes;
namespace QSDMS.Application.Web.Areas.SiteManage.Controllers
{
    public class LanguageInfoController : BaseController
    {
        //
        // GET: /SiteManage/LanguageInfo/

        [HttpGet]
        public ActionResult GetListJson()
        {
            var watch = CommonHelper.TimerStart();
            LanguageInfoEntity para = new LanguageInfoEntity();

            var list = LanguageInfoBLL.Instance.GetList(null);

            return Content(list.ToJson());
        }
    }
}
