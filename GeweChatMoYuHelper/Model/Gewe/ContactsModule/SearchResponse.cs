using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatMoYuHelper.Model.Gewe.ContactsModule
{
   public   class SearchResponse :BaseResponse
    {
        /// <summary>
        /// 通讯录数据 
        /// </summary>
        [JsonProperty("data")]
        public WechatUserInfo Data { get; set; }
    }
    /// <summary>
    /// 微信用户信息数据实体（根据2025年4月18日接口文档生成）
    /// </summary>
    public class WechatUserInfo
    {
        /// <summary>
        /// 用户加密标识符（v3协议版本）
        /// <para>格式示例：v3_020b3826...@stranger</para>
        /// <para>说明：该字段用于平台间加密通信，包含时间戳和加密设备信息</para>
        /// </summary>
        [JsonProperty("v3")]
        public string V3 { get; set; }

        /// <summary>
        /// 用户昵称 
        /// <para>最大长度：128字符</para>
        /// <para>过滤规则：支持中英文、数字及常用符号</para>
        /// </summary>
        [JsonProperty("nickName")]
        public string NickName { get; set; }

        /// <summary>
        /// 性别标识 
        /// <para>取值说明：1-男性，2-女性，0-未知（默认）</para>
        /// <para>注意：部分接口可能返回字符串类型值</para>
        /// </summary>
        [JsonProperty("sex")]
        public int Sex { get; set; }

        /// <summary>
        /// 个性签名 
        /// <para>内容限制：最多120个字符，含emoji表情编码</para>
        /// <para>显示规则：网页端自动换行，移动端单行显示</para>
        /// </summary>
        [JsonProperty("signature")]
        public string Signature { get; set; }

        /// <summary>
        /// 高清头像URL 
        /// <para>分辨率：640x640像素</para>
        /// <para>缓存策略：建议客户端缓存时长不超过7天</para>
        /// </summary>
        [JsonProperty("bigHeadImgUrl")]
        public string BigHeadImgUrl { get; set; }

        /// <summary>
        /// 缩略头像URL 
        /// <para>分辨率：132x132像素</para>
        /// <para>格式优化：WebP格式，体积缩小30%</para>
        /// </summary>
        [JsonProperty("smallHeadImgUrl")]
        public string SmallHeadImgUrl { get; set; }

        /// <summary>
        /// 增强加密标识符（v4协议版本）
        /// <para>安全特性：包含AES-256加密数据和HMAC校验码</para>
        /// <para>结构说明：@stranger表示非好友关系标识</para>
        /// </summary>
        [JsonProperty("v4")]
        public string V4 { get; set; }

    }
}
