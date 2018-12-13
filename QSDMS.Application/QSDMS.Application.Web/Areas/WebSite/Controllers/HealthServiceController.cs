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
    public class HealthServiceController : Controller
    {
        //
        // GET: /HealthService/
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 文章类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetClassList(string type)
        {
            HealthAticleEntity para = new HealthAticleEntity();
            para.LanguageKey = CurrentLanguge.LanguageKey;
            para.HealthClassId = type;
            var list = HealthAticleBLL.Instance.GetList(para).OrderBy((o) => o.CreateTime).ToList();

            return Content(list.ToJson());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDataList(string id)
        {

            var data = HealthAticleBLL.Instance.GetEntity(id);
            return Content(data.ToJson());
        }
    }
}