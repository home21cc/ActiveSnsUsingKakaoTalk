using ActiveBaseLibrary;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;

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

        public class Attach
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
        public class ResData
        {
#pragma warning disable IDE1006 // Naming Styles
            public string responseCode { get; set; }
            public string msg { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        }

        public FriendTalk()
        {
        }


        public ResData SendFriendTalk(
            string message
            , int attCode
            , string filePath)
        {

            try
            {
                ReqData request = GetReqData(message, attCode, filePath);
                string reqUrl = KakaoAPIServer + "/v2/kko/sendFriendTalk";
                Dictionary<string, string> reqMessage = new Dictionary<string, string>
                {
                    {"msgIdx", request.MsgIdx },
                    {"countryCode", request.CountryCode },
                    {"recipient", request.Receipient },
                    {"senderKey", request.SenderKey },
                    {"appUserId", request.AppUserId },
                    {"orgCode", request.OrgCode },
                    {"message", request.Message },
                    {"attach", request.Attach },
                    {"userKey", request.UserKey },
                    {"adFlag", request.AdFlag },
                    {"wide", request.Wide },
                };

                string json = JsonConvert.SerializeObject(reqMessage, Formatting.Indented);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resMessage = client.PostAsync(reqUrl, content).Result;
                return null;
            }
            catch (Exception err)
            {
                ErrorControls.WriteError(err.Message, this.GetType().Name);
                return null;
            }
        }

        private ReqData GetReqData(
            string message
            , int attCode
            , string filePath)
        {
            List<string> data = GetFilePathToData(filePath);

            ReqData result = new ReqData
            {
                MsgIdx = GetMessageKey(),                               // Y 20
                CountryCode = setting.GetDefaultValue("CountryCode"),   // Y 6
                SenderKey = setting.GetDefaultValue("SenderKey"),       // Y 40
                OrgCode = setting.GetDefaultValue("OrgCode"),           // N 20
                Message = message,                                      // Y 1000
                Attach = GetAttach(attCode, filePath),                  // N JSON
                AdFlag = setting.GetDefaultValue("AdFlag"),             // N 1
                Wide = setting.GetDefaultValue("Wide")                  // N 1
            };
            if(!string.IsNullOrWhiteSpace(data[2]) 
                || !string.IsNullOrWhiteSpace(data[3]))
            {
                result.Receipient = data[0];                            // N 20
                result.AppUserId = data[1];                             // N 20
                // 어디에서 생성하는지 잘 모름 
                result.UserKey = string.Empty;                          // N 30
            }
            return result;
        }

        private string GetMessageKey()
        {
            DateTime time = new DateTime();
            return time.ToString("yyyyMMdd") + "_" + time.ToString("HH:mm:ss:FF"); 
        }

        private string GetAttach(int attCode, string filePath)
        {
            string result = string.Empty;
            switch (attCode)
            {
                case 0:                 // 급여 파일
                    result = "";
                    break;
                default:
                    break;
            }
            return result;
        }

        private List<string> GetFilePathToData(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            string[] result = fileName.Split('_');
            return result.ToList();
        }

    }
}

