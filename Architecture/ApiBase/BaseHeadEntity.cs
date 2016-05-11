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
        protected BaseHeadEntity()
        {
            AccessToken = string.Empty;


        }

        /// <summary>
        /// 授权字符
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 用户身份
        /// </summary>
        public int Loginer { get; set; }
    }
}

