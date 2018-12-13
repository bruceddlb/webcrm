using QSDMS.Application.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QSDMS.Util;
using QSDMS.Util.Extension;
using QSDMS.Util.WebControl;
using iFramework.Framework;
using WebSiteCMS.Model;
using WebSiteCMS.Business;
namespace QSDMS.Application.Web.Areas.SiteManage.Controllers
{
    public class SiteController : BaseController
    {
        //
        // GET: /SiteManage/Site/

        public ActionResult BackGround()
        {
            return View();
        }
        /// <summary>
        /// 实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = SiteBLL.Instance.GetEntity("1");
            return Content(data.ToJson());
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="areaEntity">区域实体</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveForm(string keyValue,SiteEntity entity)
        {
            try
            {
               var data =SiteBLL.Instance.GetEntity("1");
                if(data==null)
                {
                    //新增
                    entity.SiteId = "1";
                    SiteBLL.Instance.Add(entity);
                }
                else
                {
                    data.SiteId = "1";
                    data.Back1 = entity.Back1;
                    data.Back2 = entity.Back2;
                    data.Back3 = entity.Back3;
                    data.Back4 = entity.Back4;
                    data.Back5 = entity.Back5;
                    data.Back6 = entity.Back6;
                    data.Back7 = entity.Back7;
                    data.Back8 = entity.Back8;
                    data.Back9 = entity.Back9;
                    data.Back10 = entity.Back10;
                    data.Back11 = entity.Back11;
                    SiteBLL.Instance.Update(data);

                }
                return Success("操作成功。");
            }
            catch (Exception ex)
            {
                return Error("操作失败。");
            }
        }
    }
}
