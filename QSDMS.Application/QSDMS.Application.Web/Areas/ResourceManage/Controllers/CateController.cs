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

namespace QSDMS.Application.Web.Areas.ResourceManage.Controllers
{
    public class CateController : BaseController
    {
        #region 视图功能
        /// <summary>
        /// 区域管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult List()
        {
            return View();
        }
        /// <summary>
        /// 区域表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        /// <summary>
        /// 区域详细
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Detail()
        {
            return View();
        }

        public ActionResult ChangeLg()
        {
            return View();
        }
        #endregion

        #region 获取数据

        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="value">当前主键</param>
        /// <param name="keyword">关键字查询</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            ServiceClassEntity para = new ServiceClassEntity();
            if (!string.IsNullOrWhiteSpace(queryJson))
            {
                var queryParam = queryJson.ToJObject();
                if (!queryParam["LanguageKey"].IsEmpty())
                {
                    para.LanguageKey = queryParam["LanguageKey"].ToString();
                }
                if (!queryParam["keyword"].IsEmpty())
                {
                    para.Title = queryParam["keyword"].ToString();
                }
            }
            var pageList = ServiceClassBLL.Instance.GetPageList(para, ref pagination);
            var JsonData = new
            {
                rows = pageList,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };

            return Content(JsonData.ToJson());
        }

        [HttpGet]
        public ActionResult GetListJson(string language)
        {
            var watch = CommonHelper.TimerStart();
            ServiceClassEntity para = new ServiceClassEntity();
            para.LanguageKey = language;
            var list = ServiceClassBLL.Instance.GetList(para);

            return Content(list.ToJson());
        }

        /// <summary>
        /// 实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = ServiceClassBLL.Instance.GetEntity(keyValue);
            return Content(data.ToJson());
        }
        #endregion


        #region 提交数据
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]

        public ActionResult RemoveForm(string keyValue)
        {
            //删除图片
            var model = ServiceClassBLL.Instance.GetEntity(keyValue);
            if (model != null)
            {

                //删除数据
                ServiceClassBLL.Instance.Delete(keyValue);
                return Success("删除成功。");
            }
            else
            {
                return Error("删除失败。");
            }

        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="areaEntity">区域实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, ServiceClassEntity entity)
        {
            try
            {
                if (keyValue == "")
                {
                    //新增
                    entity.ServiceClassId = Util.Util.NewUpperGuid();
                    ServiceClassBLL.Instance.Add(entity);
                }
                else
                {
                    entity.ServiceClassId = keyValue;
                    ServiceClassBLL.Instance.Update(entity);

                }
                return Success("操作成功。");
            }
            catch (Exception ex)
            {
                return Error("操作失败。");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveChangeLgForm(string keyValue, ServiceClassEntity entity)
        {
            try
            {
                if (keyValue != "")
                {
                    //新增
                    var model = ServiceClassBLL.Instance.GetEntity(keyValue);
                    if (model != null)
                    {
                        if (model.LanguageKey == entity.LanguageKey)
                        {
                            return Error("该语言已存在");
                        }
                    }
                    entity.ServiceClassId = Util.Util.NewUpperGuid();
                    ServiceClassBLL.Instance.Add(entity);
                }

                return Success("操作成功。");
            }
            catch (Exception ex)
            {
                return Error("操作失败。");
            }
        }
        #endregion



    }
}
