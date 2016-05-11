using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Architecture
{
    /// <summary>
    /// 框架枚举类
    /// </summary>
    public class ArchitectureEnums
    {
        /// <summary>
        /// 客户端类型
        /// </summary>
        public enum ClientType
        {
            [Description("PC端")]
            PC = 1,
            [Description("移动端")]
            Android = 2,
            [Description("IOS端")]
            IOS = 3,
            [Description("H5端")]
            H5 = 3,
        }

        /// <summary>
        /// Api请求响应信息
        /// </summary>
        public enum HttpResponseCode
        {
            /// <summary>
            /// 请求成功
            /// </summary>
            [Description("请求成功")]
            OK = 1,

            /// <summary>
            /// 服务繁忙
            /// </summary>
            [Description("服务繁忙")]
            ServiceBusy = 2,

            /// <summary>
            /// AccessToken 无效！
            /// </summary>
            [Description("授权码无效！")]
            InvalidSignature = 3,

            /// <summary>
            /// 未授权该api !
            /// </summary>
            [Description("未授权该api !")]
            Unauthorized = 4,

            /// <summary>
            /// 服务内部错误!
            /// </summary>
            [Description("服务内部错误!")]
            Unexception = 5,

            /// <summary>
            /// 业务处理错误!
            /// </summary>
            [Description("业务处理错误!")]
            FriendlyErrMsg = 6
        }
    }
}
