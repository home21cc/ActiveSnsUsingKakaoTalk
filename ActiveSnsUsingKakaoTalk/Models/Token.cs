using Newtonsoft.Json;

using ActiveBaseLibrary;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ActiveSnsUsingKakaoTalk.Models
{

    public class KakaoTokenModel : BaseModel
    {
        // Request Data
        public class ReqData
        {
            public string BsId { get; set; }
            public string Password { get; set; }
            public string Expire { get; set; }
        }

        // Response Data
#pragma warning disable IDE1006 // Naming Styles
        public class ResData
        {
            public string responseCode { get; set; }
            public string token { get; set; }
            public string msg { get; set; }
        }
#pragma warning restore IDE1006 // Naming Styles

        private readonly ReqData reqData = null;

        // 생성자 
        public KakaoTokenModel()
        {

        }

        public KakaoTokenModel(string bsid, string password, string expire = "1440")
        {
            reqData = new ReqData
            {
                BsId = bsid,
                Password = password,
                Expire = expire
            };
        }


        // Get Kakao Talk Token 
        public ResData GetToken()
        {
            try
            {
                if (reqData != null)
                {
                    return GetToken(reqData.BsId
                        , reqData.Password
                        , reqData.Expire);
                }
                return null;
            }
            catch (Exception err)
            {
                ErrorControls.WriteError(err.Message, this.GetType().Name);
                return null;
            }
        }

        public ResData GetToken(string bsid, string password, string expire = "1440")
        {
            try
            {
                string reqUrl = KakaoAPIServer + "/v2/auth/getToken";

                Dictionary<string, string> reqData = new Dictionary<string, string>
                {
                    {"bsid", bsid },
                    {"passwd", password },
                    {"expire", expire },
                };


                string json = JsonConvert.SerializeObject(reqData, Formatting.Indented);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resMessage = client.PostAsync(reqUrl, content).Result;

                string resState = resMessage.StatusCode.ToString();
                byte[] bytes = resMessage.Content.ReadAsByteArrayAsync().Result;
                return JsonConvert.DeserializeObject<ResData>(Encoding.UTF8.GetString(bytes));
            }
            catch (Exception err)
            {
                ErrorControls.WriteError(err.Message, this.GetType().Name);
                return null;
            }
        }
    }

}
