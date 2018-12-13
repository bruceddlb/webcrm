using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QSDMS.Util;
using WebSiteCMS.Model;
using WebSiteCMS.Business;
namespace QSDMS.Application.Web.Areas.WebSite.Controllers
{
    public class ServiceResourceController : Controller
    {
        //
        // GET: /ServiceResource/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetClassList()
        {
            ServiceClassEntity para = new ServiceClassEntity();
            para.LanguageKey = CurrentLanguge.LanguageKey;
            var list = ServiceClassBLL.Instance.GetList(para).OrderBy((o) => o.SortNum).ToList();

            return Content(list.ToJson());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDataList(string classid)
        {
            ServiceResourceEntity para = new ServiceResourceEntity();
            para.LanguageKey = CurrentLanguge.LanguageKey;
            if (!string.IsNullOrWhiteSpace(classid))
            {
                para.ClassId = classid;
            }
            var list = ServiceResourceBLL.Instance.GetList(para).OrderBy((o) => o.CreateTime).ToList();

            return Content(list.ToJson());
        }


    }
}