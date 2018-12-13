using iFramework.Framework.Log;
using QSDMS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteCMS.Business;
using WebSiteCMS.Model;

namespace QSDMS.WebSite.Web.Controllers
{
    public class BaseController : Controller
    {

        private Log _logger;
        /// <summary>
        /// 日志操作
        /// </summary>
        public Log Logger
        {
            get { return _logger ?? (_logger = LogFactory.GetLogger(this.GetType().ToString())); }
        }
        /// <summary>
        /// 返回Json对象
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        protected virtual ActionResult ToJsonResult(object data)
        {
            return Content(data.ToJson());
        }
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual ActionResult Success(string message)
        {
            ReturnMessage result = new ReturnMessage();
            result.IsSuccess = true;
            result.Message = message;
            return Content(result.ToJson());
        }
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        protected virtual ActionResult Success(string message, IDictionary<string, object> data)
        {
            ReturnMessage result = new ReturnMessage();
            result.IsSuccess = true;
            result.Message = message;
            result.ResultData = data;
            return Content(result.ToJson());
        }
        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        protected virtual ActionResult Error(string message)
        {
            ReturnMessage result = new ReturnMessage();
            result.IsSuccess = false;
            result.Message = message;
            return Content(result.ToJson());
        }



        /// <summary>
        /// 获取字典信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetLanguageName(string key)
        {
            string desc = "";
            var m = DictionaryInfoBLL.Instance.GetEntityByLanguageKey(new DictionaryInfoEntity() { DictKey = key, LanguageKey = CurrentLanguge.LanguageKey });
            if (m != null)
            {
                desc = m.Name;
            }

            return desc;
        }
        public string GetLanguageDesc(string key)
        {
            string desc = "";
            var m = DictionaryInfoBLL.Instance.GetEntityByLanguageKey(new DictionaryInfoEntity() { DictKey = key, LanguageKey = CurrentLanguge.LanguageKey });
            if (m != null)
            {
                desc = m.SortDesc;
            }

            return desc;
        }
    }

}