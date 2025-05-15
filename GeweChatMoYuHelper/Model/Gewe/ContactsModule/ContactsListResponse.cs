using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeweChatMoYuHelper.Model.Gewe.ContactsModule
{
    /// <summary>
    /// 通讯录列表响应实体 
    /// </summary>
    public class ContactsListResponse:BaseResponse
    {

        /// <summary>
        /// 通讯录数据 
        /// </summary>
        [JsonProperty("data")]
        public ContactsData Data { get; set; }
    }

    /// <summary>
    /// 通讯录数据结构 
    /// </summary>
    public class ContactsData
    {
        /// <summary>
        /// 好友wxid列表 
        /// </summary>
        [JsonProperty("friends")]
        public List<string> Friends { get; set; }

        /// <summary>
        /// 保存到通讯录的群聊ID列表 
        /// </summary>
        [JsonProperty("chatrooms")]
        public List<string> Chatrooms { get; set; }

        /// <summary>
        /// 关注的公众号ID列表 
        /// </summary>
        [JsonProperty("ghs")]
        public List<string> PublicAccounts { get; set; }
    }
}
