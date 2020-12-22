
using System;

namespace ActiveSnsUsingKakaoTalk.Models
{
    public class FriendTalk : BaseModel
    {
        enum BtnType
        {
            WL,     // Mobile & PC
            AL,     // Application 
            BK,     // Text 전송
            MD,     // Text + Message 
            BF      // 강조형 버튼
        }

        public class ReqData
        {
            public string msgIdx { get; set; }
            public string countryCode { get; set; }
            public string receipient { get; set; }
            public string appUserId { get; set; }
            public string orgCode { get; set; }
            public string message { get; set; }
            public string attach { get; set; }
            public string userKey { get; set; }
            public string adFlag { get; set; }
            public string wide { get; set; }
        }

        public class Attach
        {
            public string name { get; set; }
#pragma warning disable IDE1006 // Naming Styles
            public string type { get; set; }
#pragma warning restore IDE1006 // Naming Styles
            public string scheme_android { get; set; }
            public string scheme_ios { get; set; }
            public string url_mobile { get; set; }
            public string url_pc { get; set; }
            public string img_url { get; set; }
            public string img_link { get; set; }
        }
        public class ResData
        {
            public string responseCode { get; set; }
            public string msg { get; set; }
        }
        public FriendTalk()
        {
        }


        public ResData SendFriendTalk()
        {
            try
            {
                ReqData request = new ReqData();
                string reqUrl = KakaoAPIServer + "/v2/kko/sendFriendTalk";

                return null;

            }
            catch (Exception err)
            {
                ErrorControls.WriteError(err.Message, this.GetType().Name);
                return null;
            }
        }

    }
}

