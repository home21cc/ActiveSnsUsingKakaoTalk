using ActiveCommonLibrary;

using System;
using System.Net.Http;

namespace ActiveBaseLibrary
{
    public class BaseModel : object, IDisposable
    {
        public Setting setting = new Setting();
        public HttpClient client = new HttpClient();
        public string BizTalkAPIServer { get; set; }
        public string BizTalkUserId { get; set; }
        public string BizTalkPassword { get; set; }
        public string BizTalkExpire { get; set; }
        public string BizTalkToken { get; set; }

        public BaseModel()
        {
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("ContentEncoding", "UTF-8");

            BizTalkAPIServer = setting.GetDefaultValue("BizTalkServer");
            BizTalkUserId = setting.GetDefaultValue("BizTalkId");
            BizTalkPassword = setting.GetDefaultValue("BizTalkPassword");
            BizTalkExpire = setting.GetDefaultValue("BizTalkExpire");
        }
        public void Dispose()
        {
            if(client != null)
            {
                client.Dispose();
            }
        }
    }
}
