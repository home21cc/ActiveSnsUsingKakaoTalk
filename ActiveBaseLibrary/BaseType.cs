using System;
using System.Collections.Generic;
using System.Text;

namespace ActiveBaseLibrary
{
    #region Common
    public enum BizTalkKeyType
    {
        RecipientKey,           // 수신자 전화번호
        AppUserIdKey,           // 카카오톡 계정
        UserKey                 // 카카오톡 채널 사용자 식별키
    }
    #endregion Common


    #region Friend Talk 
    public class FriendRequestData
    {
        public string MsgIdx { get; set; }
        public string CountryCode { get; set; }
        public string Receipient { get; set; }
        public string SenderKey { get; set; }
        public string AppUserId { get; set; }
        public string OrgCode { get; set; }
        public string Message { get; set; }
        public string Attach { get; set; }
        public string UserKey { get; set; }
        public string AdFlag { get; set; }
        public string Wide { get; set; }
    }

    public class FriendAttach
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Scheme_android { get; set; }
        public string Scheme_ios { get; set; }
        public string Url_mobile { get; set; }
        public string Url_pc { get; set; }
        public string Img_url { get; set; }
        public string Img_link { get; set; }
    }

    public class FriendResponseData
    {
        #pragma warning disable IDE1006 // Naming Styles
        public string responseCode { get; set; }
        public string msg { get; set; }
        #pragma warning restore IDE1006 // Naming Styles
    }

    #endregion Friend Talk 

    #region Token 
    // Tocken Response Data
    public class TokenResponseData
    {
        #pragma warning disable IDE1006 // Naming Styles
        public string responseCode { get; set; }
        public string token { get; set; }
        public string msg { get; set; }
        #pragma warning restore IDE1006 // Naming Styles
    }
    #endregion Token
}
