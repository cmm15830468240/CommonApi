using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.WebPages;


namespace Architecture
{
    /// <summary>
    /// Razor基类
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public abstract class IViewBase<TModel> : WebViewPage<TModel>
    {
        public string BasePath
        {

            get
            {
                string basePath = Url.Content("~");
                return basePath;
            }

        }

        /// <summary>
        /// 得到主机
        /// </summary>
        public string Host
        {
            get
            {
                return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.IndexOf(Request.RawUrl)) + BasePath;
            }
        }

        protected override void InitializePage()
        {
            base.InitializePage();
        }
      
    }
}
