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
                request.MsgIdx = GetMessageIndex();
                if (keyType == BizTalkKeyType.AppUserIdKey)
                    request.Receipient = keyValue;
                if (keyType == BizTalkKeyType.RecipientKey)
                    request.AppUserId = keyValue;
                request.Message = message;
                request.Attach = GetAttach(attCode, msgTitle, filePath);
                string x = GetAttach(attCode, msgTitle, filePath);
                if (keyType == BizTalkKeyType.UserKey)
                    request.UserKey = keyValue;

                string reqUrl = BizTalkAPIServer + "/v2/kko/sendFriendTalk";
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

        private string GetAttach(int attCode, string msgTitle, string filePath)
        {
            StringBuilder result = new StringBuilder();
            switch (attCode)
            {
                case 0:
                    result.Append("{");
                    result.Append("button:[");
                    result.Append("{");
                    result.Append("name:");
                    result.Append(msgTitle);
                    result.Append(",");
                    result.Append("type:WL,");
                    result.Append("url_pc:http://www.tkbend.co.kr/,");
                    result.Append("url_mobile:http://www.tkbend.co.kr/");
                    result.Append("}");
                    result.Append("],");
                    result.Append("image:{");
                    result.Append("image_url:http://bizmessage.kakao.com/");
                    result.Append(filePath);
                    result.Append(",");
                    result.Append("image_link:http://bizmessage.kakao.com/");
                    result.Append(filePath);
                    result.Append("}");
                    result.Append("}");
                    break;
                default:
                    break;
            }
            return result.ToString();
        }

    }
}

