using ActiveBaseLibrary;

using ActiveCommonLibrary;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ActiveSnsUsingKakaoTalk.Models
{
    public class BizTalkFriendModel : BaseModel
    {
        readonly FriendRequestData request = null;
        public BizTalkFriendModel()
        {
            request = new FriendRequestData()
            {
                CountryCode = setting.GetDefaultValue("CountryCode"),
                SenderKey = setting.GetDefaultValue("SenderKey"),
                OrgCode = setting.GetDefaultValue("Organization"),
                AdFlag = setting.GetDefaultValue("AdFlag"),
                Wide = setting.GetDefaultValue("Wide"),
            };
        }

        public FriendResponseData SendFriendTalk(
            BizTalkKeyType keyType
            , string keyValue
            , string msgTitle
            , string message
            , int attCode
            , string filePath)
        {
            try
            {   
                string reqUrl = BizTalkAPIServer + "/v2/kko/sendFriendTalk";
                string json = GetJsonString(keyType, keyValue, msgTitle, message, attCode, filePath);
                client.DefaultRequestHeaders.Add("bt-token", setting.GetDefaultValue("BizTalkToken"));
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resMessage = client.PostAsync(reqUrl, content).Result;

                byte[] bytes = resMessage.Content.ReadAsByteArrayAsync().Result;
                return JsonConvert.DeserializeObject<FriendResponseData>(Encoding.UTF8.GetString(bytes));
            }
            catch (Exception err)
            {
                Error.WriteError(err.Message, this.GetType().Name);
                return null;
            }
        }

        private string GetMessageIndex()
        {
            DateTime time = DateTime.Now;
            // TODO : 데이터 반환이 이상함 
            return time.ToString("yyyy")
                + time.ToString("MM")
                + time.ToString("dd")
                + time.ToString("HH")
                + time.ToString("mm")
                + time.ToString("ss")
                + time.ToString("ffffff");
        }

        private string GetJsonString(BizTalkKeyType keyType
            , string keyValue
            , string msgTitle
            , string message
            , int attCode
            , string filePath)
        {
            string startTag         = "{\r\n \"";
            string contentTag       = "\":\"";
            string contentAttTag    = "\":";
            string chapterTag       = "\",\r\n \"";
            string endTag           = "\r\n}";
            StringBuilder result = new StringBuilder();
            result.Append(startTag);

            // MessageIndex
            result.Append("msgIdx");
            result.Append(contentTag);
            result.Append(GetMessageIndex());
            
            // CountryCode
            result.Append(chapterTag);
            result.Append("countryCode");
            result.Append(contentTag);
            result.Append(setting.GetDefaultValue("CountryCode"));

            // SenderKey
            result.Append(chapterTag);
            result.Append("senderKey");
            result.Append(contentTag);
            result.Append(setting.GetDefaultValue("SenderKey"));

            // Organization
            result.Append(chapterTag);
            result.Append("orgCode");
            result.Append(contentTag);
            result.Append(setting.GetDefaultValue("Organization"));

            // Mesage
            result.Append(chapterTag);
            result.Append("message");
            result.Append(contentTag);
            result.Append(message);

            // AdFlag
            result.Append(chapterTag);
            result.Append("adFlag");
            result.Append(contentTag);
            result.Append(setting.GetDefaultValue("AdFlag"));

            // Wide
            result.Append(chapterTag);
            result.Append("wide");
            result.Append(contentTag);
            result.Append(setting.GetDefaultValue("Wide"));

            // Recipient, AppUserId, UserKey 
            result.Append(chapterTag);
            switch (keyType)
            {
                case BizTalkKeyType.RecipientKey:
                    result.Append("recipient");
                    break;
                case BizTalkKeyType.AppUserIdKey:
                    result.Append("appUserId");
                    break;
                case BizTalkKeyType.UserKey:
                    result.Append("userKey");
                    break;
            }
            result.Append(contentTag);
            result.Append(keyValue);

            // Attach 
            result.Append(chapterTag);
            result.Append("attach");
            result.Append(contentAttTag);
            result.Append(GetAttach(attCode, msgTitle, filePath));

            result.Append(endTag);
            return result.ToString();
        }

        private string GetAttach(int attCode, string msgTitle, string filePath)
        {
            string startTag         = "{\r\n\"";
            string buttonStartTag   = "\":[\r\n{\r\n\"";
            string buttonEndTag     = "\"\r\n}\r\n],\r\n\"";
            string imageStartTag    = "\":{\r\n\"";
            string contentTag       = "\":\"";
            string chapterTag       = "\",\r\n\"";
            string endTag           = "\"\r\n}\r\n}";
            StringBuilder result = new StringBuilder();
            switch (attCode)
            {
                case 0:
                    result.Append(startTag);
                    
                    result.Append("button");
                    result.Append(buttonStartTag);
                    
                    result.Append("name");
                    result.Append(contentTag);
                    result.Append(msgTitle);

                    result.Append(chapterTag);
                    result.Append("type");
                    result.Append(contentTag);
                    result.Append("WL");

                    result.Append(chapterTag);
                    result.Append("url_pc");
                    result.Append(contentTag);
                    result.Append("http://www.tkbend.co.kr/");

                    result.Append(chapterTag);
                    result.Append("url_mobile");
                    result.Append(contentTag);
                    result.Append("http://www.tkbend.co.kr/");
                    
                    result.Append(buttonEndTag);

                    result.Append("image");
                    result.Append(imageStartTag);
                    result.Append("image_url");
                    result.Append(contentTag);
                    result.Append("https://github.com/home21cc/PayRolls/blob/main/myPayroll.jpg");
                    result.Append(filePath);

                    result.Append(endTag);
                    break;
                default:
                    break;
            }
            return result.ToString();
        }

    }
}

