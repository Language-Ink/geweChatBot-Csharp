using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatMoYuHelper.Model.Gewe.LoginModule
{
    /// <summary>
    /// 接口checkOnline的出参实体类。
    /// </summary>
    public class CheckOnlineResponse:BaseResponse
    {

        /// <summary>
        /// 数据部分，包含具体的业务数据。
        /// </summary>
        public bool Data { get; set; }
    }
}
