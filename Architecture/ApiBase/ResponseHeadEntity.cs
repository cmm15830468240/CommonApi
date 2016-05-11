using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.ApiBase
{
    /// <summary>
    /// 响应头部描述信息
    /// </summary>
    public abstract class ResponseHeadEntity
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        protected ResponseHeadEntity()
        {
            rspCode = string.Empty;
            rspDesc = string.Empty;
        }

        /// <summary>
        /// 响应标识
        /// </summary>
        public string rspCode { get; set; }

        /// <summary>
        /// 响应信息描述
        /// </summary>
        public string rspDesc { get; set; }
    }
}
