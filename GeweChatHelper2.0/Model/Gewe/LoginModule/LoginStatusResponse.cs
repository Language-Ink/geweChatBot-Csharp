using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatHelper2._0.Model.Gewe.LoginModule
{/// <summary>
 /// 登录状态响应（API: /login/checkQrCode）
 /// </summary>
    public class LoginStatusResponse : BaseResponse
    {
        /// <summary>
        /// 登录状态数据 
        /// </summary>
        [JsonProperty("data")]
        public LoginStatusData Data { get; set; }
    }

    /// <summary>
    /// 登录状态详情 
    /// </summary>
    public class LoginStatusData
    {
        /// <summary>
        /// 当前会话UUID（与二维码生成返回一致）
        /// </summary>
        [JsonProperty("uuid")]
        public string SessionId { get; set; }

        /// <summary>
        /// 用户头像URL（未登录时返回默认头像）
        /// </summary>
        [JsonProperty("headImgUrl")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// 用户昵称（未登录时返回空）
        /// </summary>
        [JsonProperty("nickName")]
        public string Nickname { get; set; }

        /// <summary>
        /// 二维码过期时间戳（单位：秒）
        /// </summary>
        [JsonProperty("expiredTime")]
        public int ExpireTimestamp { get; set; }

        /// <summary>
        /// 登录状态（1=待确认，2=已登录，3=已过期）
        /// </summary>
        [JsonProperty("status")]
        public LoginState Status { get; set; }

        /// <summary>
        /// 登录成功后的用户凭证（仅status=2时返回）
        /// </summary>
        [JsonProperty("loginInfo")]
        public UserAuthInfo AuthInfo { get; set; }
    }

    /// <summary>
    /// 用户认证信息 
    /// </summary>
    public class UserAuthInfo
    {
        /// <summary>
        /// 用户唯一标识（腾讯内部ID）
        /// </summary>
        [JsonProperty("uin")]
        public long UserId { get; set; }

        /// <summary>
        /// 微信ID（格式：wxid_xxxxxxxxxxxx）
        /// </summary>
        [JsonProperty("wxid")]
        public string WechatId { get; set; }

        /// <summary>
        /// 用户昵称（可能与扫码时的昵称不同）
        /// </summary>
        [JsonProperty("nickName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// 绑定手机号（可能为空）
        /// </summary>
        [JsonProperty("mobile")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 微信号（用户设置的唯一标识）
        /// </summary>
        [JsonProperty("alias")]
        public string AccountName { get; set; }
    }

    /// <summary>
    /// 登录状态枚举 
    /// </summary>
    public enum LoginState
    {
        Pending = 1,
        Success = 2,
        Expired = 3
    }
}
