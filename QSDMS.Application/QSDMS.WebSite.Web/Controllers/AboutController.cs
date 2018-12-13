using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteCMS.Business;
using WebSiteCMS.Model;

namespace QSDMS.WebSite.Web.Controllers
{
    public class AboutController : BaseController
    {
        //
        // GET: /About/
        public ActionResult Index()
        {
            ViewBag.Info = "";
            var m = DictionaryInfoBLL.Instance.GetEntityByLanguageKey(new DictionaryInfoEntity() { DictKey = "Home1", LanguageKey = CurrentLanguge.LanguageKey });
            if (m != null)
            {
                ViewBag.Info = m.Content;
            }           
            return View();
        }
	}
}