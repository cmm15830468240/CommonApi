using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Api.ApiBase
{
    /// <summary>
    /// 响应头部描述信息
    /// </summary>
    public class BaseHeadResponse
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public BaseHeadResponse()
        {
            rspCode = string.Empty;
            rspDesc = string.Empty;
        }

        /// <summary>
        /// 响应标识【ArchitectureEnums】
        /// </summary>
        public string rspCode { get; set; }

        /// <summary>
        /// 响应信息描述【ArchitectureEnums】
        /// </summary>
        public string rspDesc { get; set; }
    }
}
