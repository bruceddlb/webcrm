using iFramework.Framework.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QSDMS.Application.Web.Areas.WebSite.Controllers
{
    /// <summary>
    /// Ajax页面自定义属性，对于Ajax请求的Action请添加此属性[AjaxPage]
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class AjaxPageAttribute : Attribute
    {

    }
    /// <summary>
    /// Action权限过滤
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeFilterAttribute : ActionFilterAttribute
    {
        private Log _logger;
        /// <summary>
        /// 日志操作
        /// </summary>
        public Log Logger
        {
            get { return _logger ?? (_logger = LogFactory.GetLogger(this.GetType().ToString())); }
        }

        /// <summary>默认构造</summary>
        /// <param name="Mode">认证模式</param>
        public AuthorizeFilterAttribute()
        {

        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //获取Action是否有AjaxPage属性
            object[] attrs = filterContext.ActionDescriptor.GetCustomAttributes(typeof(AjaxPageAttribute), true);
            bool isAjax = attrs.Length == 1;
            //标记ajax方法则不判断权限
            if (isAjax)
            {
                return;
            }
            //验证请求的action
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }


        }

    }

    /// <summary>
    /// 当前语言
    /// </summary>
    public class CurrentLanguge
    {
        private static Log _logger;
        /// <summary>
        /// 日志操作
        /// </summary>
        public static Log Logger
        {
            get { return _logger ?? (_logger = LogFactory.GetLogger("CurrentLanguge")); }
        }
        /// <summary>
        /// 当前语言
        /// </summary>
        public static string LanguageKey
        {
            get
            {
                string lang = "cn";
                if (HttpContext.Current.Request != null)
                {

                    lang = HttpContext.Current.Request.QueryString["languge"] ?? "";
                    if (string.IsNullOrEmpty(lang))
                    {
                        HttpCookie ulanguage = HttpContext.Current.Request.Cookies.Get("userlangue");
                        if (ulanguage != null)
                        {
                            lang = ulanguage.Value;
                        }
                        else
                        {
                            lang = "cn";
                            HttpCookie cookie = new HttpCookie("userlangue");
                            cookie.Value = lang;
                            HttpContext.Current.Response.Cookies.Add(cookie);
                        }
                    }
                    else
                    {
                        HttpCookie cookie = new HttpCookie("userlangue");
                        cookie.Value = lang;
                        HttpContext.Current.Response.Cookies.Add(cookie);
                    }
                }

                return lang;
            }
        }

    }
}