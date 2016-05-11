using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Access
{
    /// <summary>
    /// 访问者信息
    /// </summary>
    public interface AccessInfo
    {
        /// <summary>
        /// 访问者信息
        /// </summary>
        User Accesser { get; set; }

        /// <summary>
        /// 访问者客户端信息
        /// </summary>
        Client AccessClient { get; set; }

    }


    /// <summary>
    /// 登陆者信息
    /// </summary>
    public class User
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 账户
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }

    /// <summary>
    /// 客户端信息
    /// </summary>
    public class Client
    {
         



    }
}
