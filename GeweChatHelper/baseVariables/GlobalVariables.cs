using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatHelper.baseVariables
{
    /// <summary>
    /// 全局变量类，用于存放全局变量。
    /// </summary>
    public class GlobalVariables
    {
        /// <summary>
        /// 微信服务器地址
        /// </summary>
        public static string BaseUrl = "http://192.168.7.9:2531/v2/api";
        /// <summary>
        /// 微信token
        /// </summary>
        public static string Token = "";
        /// <summary>
        /// 微信appid
        /// </summary>
        public static string AppId = "";
    }
}
