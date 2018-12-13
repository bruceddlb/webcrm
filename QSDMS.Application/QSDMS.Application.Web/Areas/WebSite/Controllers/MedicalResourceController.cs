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
    public class MedicalResourceController : Controller
    {
        //
        // GET: /MedicalResource/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetMedicalList()
        {
            MedicalResourceEntity para = new MedicalResourceEntity();
            para.LanguageKey = CurrentLanguge.LanguageKey;
            var list = MedicalResourceBLL.Instance.GetList(para).OrderBy((o) => o.CreateTime).ToList();

            return Content(list.ToJson());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetHotelList()
        {
            HotelResourceEntity para = new HotelResourceEntity();
            para.LanguageKey = CurrentLanguge.LanguageKey;
            var list = HotelResourceBLL.Instance.GetList(para).OrderBy((o) => o.CreateTime).ToList();

            return Content(list.ToJson());
        }

    }
}