using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.ApiBase
{
    /// <summary>
    /// 基础请求信息
    /// </summary>
    public abstract class BaseHeadEntity
    {
        /// <summary>
        /// 授权字符
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int LoginId { get; set; }
    }
}

