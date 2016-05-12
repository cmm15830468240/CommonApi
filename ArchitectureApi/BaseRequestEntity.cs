using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Architecture.Api.ApiBase;

namespace Architecture.Api
{
    /// <summary>
    /// Api请求实体基础接口
    /// </summary>
    public interface IBaseRequest
    {
        /// <summary>
        /// 请求Header信息
        /// </summary>
        BaseHeadRequest Header { get; set; }
    }

    /// <summary>
    /// Api HttpRequest请求参数类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRequestEntity<T> : IBaseRequest where T : new()
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseRequestEntity()
        {
            Header = new BaseHeadRequest();
        }

        /// <summary>
        /// 请求Header信息
        /// </summary>
        public BaseHeadRequest Header { get; set; }


        private T _body = new T();

        /// <summary>
        /// 请求参数信息
        /// </summary>
        public T Body { get { return _body; } set { _body = value; } }
    }
}
