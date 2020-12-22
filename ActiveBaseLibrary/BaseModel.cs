using System;
using System.Net.Http;

namespace ActiveBaseLibrary
{
    public class BaseModel : object, IDisposable
    {
        public Setting setting = new Setting();
        public HttpClient client = new HttpClient();
        public string KakaoAPIServer { get; set; }
        public string KakaoToken { get; set; }

        public BaseModel()
        {
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("ContentEncoding", "UTF-8");
            KakaoAPIServer = setting.GetDefaultValue("KakaoTalkServer");
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
