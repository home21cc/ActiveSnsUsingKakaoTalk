using Newtonsoft.Json;

using ActiveCommonLibrary;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ActiveBaseLibrary;

namespace ActiveSnsUsingKakaoTalk.Models
{

    public class BizTalkTokenModel : BaseModel
    {   
        

        public string ResponseToken { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }

        // Creator
        public BizTalkTokenModel()
        {
            if (string.IsNullOrEmpty(ResponseToken) || string.IsNullOrWhiteSpace(ResponseToken))
            {
                BizTalkUserId = setting.GetDefaultValue("BizTalkUserId");
                BizTalkPassword = setting.GetDefaultValue("BizTalkPassword");
                BizTalkExpire = setting.GetDefaultValue("BizTalkExpire");
                GenToken();
            }
        }

        public void GenToken()
        {
            try
            {
                string reqUrl = BizTalkAPIServer + "/v2/auth/getToken";

                Dictionary<string, string> reqData = new Dictionary<string, string>
                {
                    {"bsid", BizTalkUserId },
                    {"passwd", BizTalkPassword },
                    {"expire", BizTalkExpire },
                };

                string json = JsonConvert.SerializeObject(reqData, Formatting.Indented);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resMessage = client.PostAsync(reqUrl, content).Result;

                string resState = resMessage.StatusCode.ToString();
                byte[] bytes = resMessage.Content.ReadAsByteArrayAsync().Result;
                TokenResponseData result = JsonConvert.DeserializeObject<TokenResponseData>(Encoding.UTF8.GetString(bytes));
                ResponseToken = result.token;
                ResponseCode = result.responseCode;
                ResponseMessage = result.msg;

                if(setting.GetDefaultValue("BizTalkToken") != ResponseToken)
                {
                    setting.SetDefaultValue("BizTalkToken", ResponseToken);
                }
            }
            catch (Exception err)
            {
                Error.WriteError(err.Message, this.GetType().Name);
            }
        }
    }

}
