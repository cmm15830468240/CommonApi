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
            return View(loginer);
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
    }
}