using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QSDMS.Util;
using WebSiteCMS.Business;
using WebSiteCMS.Model;
namespace QSDMS.Application.Web.Areas.SiteManage.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /SiteManage/Home/

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetHomeJson()
        {
            //HomeEntity data = new HomeEntity();
            //data.StudyCount = StudyOrderBLL.Instance.GetList(null).Where(o => o.Status != (int)RCHL.Model.Enums.StudySubscribeStatus.取消).Count();
            //data.TrainingCount = TrainingOrderBLL.Instance.GetList(null).Where(o => o.Status != (int)RCHL.Model.Enums.TrainingStatus.已取消).Count();
            //data.WithDrivingCount = WithDrivingOrderBLL.Instance.GetList(null).Where(o => o.Status != (int)RCHL.Model.Enums.PaySatus.已取消).Count();
            //data.AuditCount = AuditOrderBLL.Instance.GetList(null).Where(o => o.Status != (int)RCHL.Model.Enums.PaySatus.已取消).Count();
            //data.TakeAuditCount = TakeAuditOrderBLL.Instance.GetList(null).Where(o => o.Status != (int)RCHL.Model.Enums.PaySatus.已取消).Count();
            var data = new
            {
                CompayNewCount = NewsBLL.Instance.GetList(new NewsEntity() { Type = 1 }).Count,
                HealthNewCount = NewsBLL.Instance.GetList(new NewsEntity() { Type = 2 }).Count,
                ServiceResourceCount = ServiceResourceBLL.Instance.GetList(null).Count,
                MedicalResourceCount = MedicalResourceBLL.Instance.GetList(null).Count,
                HealthAticleCount = HealthAticleBLL.Instance.GetList(null).Count,
            };
            return Content(data.ToJson());
        }
    }
    public class HomeEntity
    {

        public int StudyCount { get; set; }

        public int TrainingCount { get; set; }
        public int WithDrivingCount { get; set; }

        public int AuditCount { get; set; }

        public int TakeAuditCount { get; set; }
    }
}
