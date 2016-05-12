using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Api.ApiBase
{
    /// <summary>
    /// 访问者信息
    /// </summary>
    public class AccessInfo
    {
        /// <summary>
        /// 访问者信息
        /// </summary>
        public User Accesser { get; set; }

        /// <summary>
        /// 访问者客户端信息
        /// </summary>
        public Client AccessClient { get; set; }

    }


    /// <summary>
    /// 登陆者信息
    /// </summary>
    public class User
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public User()
        {
            Guid = string.Empty;
            Name = string.Empty;
            Account = string.Empty;
        }

        /// <summary>
        /// 登陆者唯一标识
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// 登陆者名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 登陆者账户
        /// </summary>
        public string Account { get; set; }

    }

    /// <summary>
    /// 客户端信息
    /// </summary>
    public class Client
    {
        /// <summary>
        /// 客户端类型【ArchitectureEnums】
        /// </summary>
        public int ClientType { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string VersionNo { get; set; }

    }
}
