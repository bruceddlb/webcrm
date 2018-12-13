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
    public class NewsController : BaseController
    {
        //
        // GET: /News/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(string id)
        {
            var entity = NewsBLL.Instance.GetEntity(id);
            return View(entity);
        }

        /// <summary>
        /// 查询新闻
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetNewsPageList(int? page, int? pagesize, int type)
        {
            Pagination pagination = new Pagination();
            pagination.rows = pagesize ?? 10;
            pagination.page = page ?? 1;
            NewsEntity para = new NewsEntity();
            para.Type = type;
            para.LanguageKey = CurrentLanguge.LanguageKey;
            pagination.sidx = "CreateTime";
            pagination.sord = "desc";
            var pageList = NewsBLL.Instance.GetPageList(para, ref pagination);
            var JsonData = new
            {
                rows = pageList,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
            };

            return Content(JsonData.ToJson());
        }

    }
}