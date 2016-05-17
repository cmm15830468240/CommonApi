using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Architecture;
using DataEntity;

namespace CommonApi.Controllers
{
 
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View(new Loginer());
        }

        [HttpPost]
        public ActionResult Login(Loginer loginer)
        {
            if (ModelState.IsValid)
            {
                if (loginer.ValidateCode != Session["ValidateCode"] as string)
                {
                    ModelState.AddModelError("", "验证码错误!");
                    return View(loginer);
                }


                if (!loginer.Account.ToLower().Equals("demo") || !loginer.Password.ToLower().Equals("demo"))
                {
                    ModelState.AddModelError("", "未授权用户,登陆失败!");

                    return View(loginer);
                }
            }

            HttpContext.Session["UserInfo"] = loginer;

            var returnUrl = GetReturnUrl();
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Help");
        }


        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 生成验证码图像对象
        /// </summary>
        /// <returns></returns>
        public ActionResult GetValidateCode()
        {
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(4);
            Session["ValidateCode"] = code;
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }

        /// <summary>
        /// 解析URL回跳地址
        /// </summary>
        /// <returns></returns>
        private string GetReturnUrl()
        {
            if (Request == null)
            {
                return string.Empty;
            }

            if (Request.UrlReferrer == null)
            {
                return string.Empty;
            }

            if (Request.UrlReferrer.Query == null)
            {
                return string.Empty;
            }

            var query = HttpContext.Server.UrlDecode(Request.UrlReferrer.Query);
            if (query.Contains('$'))
            {
                var arr = query.Split(new char[] {'$'}, StringSplitOptions.RemoveEmptyEntries);
                if (arr != null && arr.Length == 2)
                    return arr[1];
            }
            return string.Empty;
        }
    }
}