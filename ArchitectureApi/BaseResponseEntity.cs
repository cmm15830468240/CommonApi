using Architecture.Api.ApiBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture
{
    /// <summary>
    /// HttpResponse信息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponseEntity<T> where T : new()
    {
        public BaseResponseEntity()
        {
            Header = new BaseHeadResponse()
            {
                rspCode = ArchitectureEnums.HttpResponseCode.OK.ToString("d"),
                //rspDesc = EnumExt.GetDes(HttpResponseCode.OK)
            };
        }
        public BaseHeadResponse Header { get; set; }

        private T _body = new T();
        public T Body { get { return _body; } set { _body = value; } }
    }

}
