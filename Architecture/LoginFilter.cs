using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DataEntity;


namespace Architecture
{
    /// <summary>
    /// Web文档查看权限验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class LoginFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 权限拦截
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //未登录验证
            var loginer = filterContext.HttpContext.Session["UserInfo"] as Loginer;

            string redirectUrl = string.Empty;

            if (loginer == null || string.IsNullOrEmpty(loginer.Account) || string.IsNullOrEmpty(loginer.Password))
            {
                redirectUrl = "~/Home/Index?ReturnUrl$" +
                              filterContext.HttpContext.Server.UrlEncode(filterContext.HttpContext.Request.Url == null
                                  ? ""
                                  : filterContext.HttpContext.Request.Url.AbsoluteUri);
                filterContext.HttpContext.Response.Redirect(redirectUrl);
            }
        }
    }
}
