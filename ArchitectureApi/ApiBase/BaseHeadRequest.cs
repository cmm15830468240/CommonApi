using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Api.ApiBase
{
    /// <summary>
    /// 基础请求信息
    /// </summary>
    public class BaseHeadRequest
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseHeadRequest()
        {
            AccessToken = string.Empty;
            AccessInfomation = new AccessInfo();
        }

        /// <summary>
        /// 授权字符
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 访问者信息
        /// </summary>
        public AccessInfo AccessInfomation { get; set; }
    }
}

