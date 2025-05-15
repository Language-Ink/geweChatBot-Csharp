using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatMoYuHelper.baseVariables
{
    /// <summary>
    /// 全局变量类，用于存放全局变量。
    /// </summary>
    public class GlobalVariables
    {
        /// <summary>
        /// 微信服务器地址
        /// </summary>
        public static  string  BaseUrl = "http://127.0.0.1:2531/v2/api";
        /// <summary>
        /// 微信token
        /// </summary>
        public static string Token = "";
        /// <summary>
        /// 微信appid
        /// </summary>
        public static string AppId = "";

        /// <summary>
        /// 微信UUId
        /// </summary>
        public static string UUId = "";
    }
    /// <summary>
    /// 全局变量类，用于存放全局变量。
    /// </summary>
    public class GlobalVariablesData
    {
        /// <summary>
        /// 微信服务器地址
        /// </summary>
        public  string BaseUrl { get; set; }
        /// <summary>
        /// 微信token
        /// </summary>
        public  string Token { get; set; }
        /// <summary>
        /// 微信appid
        /// </summary>
        public  string AppId { get; set; }

        /// <summary>
        /// 微信UUId
        /// </summary>
        public  string UUId { get; set; }
    }
}
