using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Architecture
{
    /// <summary>
    /// Web项目登陆权限验证
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
            var loginer = filterContext.HttpContext.Session["UserInfo"];

            string redirectUrl = string.Empty;

            if (loginer == null)
            {
                redirectUrl = "~/Home/Login?ReturnUrl$" + filterContext.HttpContext.Server.UrlEncode(filterContext.HttpContext.Request.Url == null ? "" : filterContext.HttpContext.Request.Url.AbsoluteUri);
                filterContext.HttpContext.Response.Redirect(redirectUrl);
            }
        }
    }
}
