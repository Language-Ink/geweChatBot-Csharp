using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatHelper.Model
{
    // 定义响应数据的类
    public class ApiResponse<T>
    {
        public int Ret { get; set; }
        public string Msg { get; set; }
        public T Data { get; set; }
    }

    public class ApiResponse
    {
        public int Ret { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }
}
