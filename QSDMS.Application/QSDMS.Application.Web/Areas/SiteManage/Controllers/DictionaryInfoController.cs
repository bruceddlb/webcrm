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
    public class DictionaryInfoController : BaseController
    {
        //
        // GET: /SiteManage/DictionaryInfo/

        public ActionResult List()
        {
            return View();
        }
        public ActionResult Form()
        {
            return View();
        }

        public ActionResult ChangeLg() {
            return View();
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            DictionaryInfoEntity para = new DictionaryInfoEntity();
            if (!string.IsNullOrWhiteSpace(queryJson))
            {
                var queryParam = queryJson.ToJObject();
                if (!queryParam["LanguageKey"].IsEmpty())
                {
                    para.LanguageKey = queryParam["LanguageKey"].ToString();
                }
                if (!queryParam["keyword"].IsEmpty())
                {
                    para.Name = queryParam["keyword"].ToString();
                }
            }

            var pageList = DictionaryInfoBLL.Instance.GetPageList(para, ref pagination);

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

        /// <summary>
        /// 实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = DictionaryInfoBLL.Instance.GetEntity(keyValue);
            return Content(data.ToJson());
        }
        /// <summary>
        /// 实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpPost]
        public ActionResult RemoveForm(string keyValue)
        {
            try
            {
                DictionaryInfoBLL.Instance.Delete(keyValue);
                return Success("删除成功");
            }
            catch (Exception ex)
            {
                ex.Data["Method"] = "DictionaryInfoController>>RemoveForm";
                new ExceptionHelper().LogException(ex);
                return Error("删除失败");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, DictionaryInfoEntity entity)
        {
            try
            {

                entity.Content = entity.Content == null ? "" : entity.Content.Replace("&amp;", "&").Replace("&gt;", ">").Replace("&lt;", "<");
                if (keyValue != "")
                {
                    
                    entity.DictionaryInfoId = keyValue;
                    DictionaryInfoBLL.Instance.Update(entity);
                }
                else
                {
                    //var model = DictionaryInfoBLL.Instance.GetEntity(keyValue);
                    //if (model != null)
                    //{
                    //    if (model.LanguageKey == entity.LanguageKey)
                    //    {
                    //        return Error("该语言已存在");
                    //    }
                    //}
                    entity.DictionaryInfoId = Util.Util.NewUpperGuid();
                    entity.CreateTime = DateTime.Now;
                    DictionaryInfoBLL.Instance.Add(entity);
                }

                return Success("保存成功");
            }
            catch (Exception ex)
            {
                ex.Data["Method"] = "DictionaryInfoController>>SaveForm";
                new ExceptionHelper().LogException(ex);
                return Error("保存失败");
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
        public ActionResult SaveChangeLgForm(string keyValue, DictionaryInfoEntity entity)
        {
            try
            {
                if (keyValue != "")
                {
                    //新增
                    var model = DictionaryInfoBLL.Instance.GetEntity(keyValue);
                    if (model != null)
                    {
                        if (model.LanguageKey == entity.LanguageKey) {
                            return Error("该语言已存在");
                        }
                    }
                    entity.Content = entity.Content == null ? "" : entity.Content.Replace("&amp;", "&").Replace("&gt;", ">").Replace("&lt;", "<");
                    entity.DictionaryInfoId = Util.Util.NewUpperGuid();
                    entity.CreateTime = DateTime.Now;
                    DictionaryInfoBLL.Instance.Add(entity);
                }
              
                return Success("操作成功。");
            }
            catch (Exception ex)
            {
                return Error("操作失败。");
            }
        }
     
        /// <summary>
        /// 判断关键字重复
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="ChanneKey"></param>
        /// <param name="lankey"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ExistKey(string keyValue, string DictKey, string lankey)
        {
            bool IsOk = DictionaryInfoBLL.Instance.ExistKey(DictKey, lankey, keyValue);
            return Content(IsOk.ToString());
        }

    }
}
