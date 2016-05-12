using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace Architecture.Api
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class ApiFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 请求安全性验证
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            if (actionContext.ActionArguments.Count > 0)
            {
                if (actionContext.ActionArguments.First().Value is IBaseRequest)
                {
                    var requestEntity = (IBaseRequest)actionContext.ActionArguments.First().Value;
                    if (requestEntity != null && requestEntity.Header.AccessToken != null
                        && !string.IsNullOrEmpty(requestEntity.Header.AccessToken))
                    {

                        bool validated = false;//logic todo:
                        if (validated)
                        {
                            actionContext.Response = null;
                        }
                    }
                }

            }

        }

    }
}
