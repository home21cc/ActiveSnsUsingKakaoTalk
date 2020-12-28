using ActiveCommonLibrary;

using ActiveSnsUsingKakaoTalk.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace ActiveSnsUsingKakaoTalk.Controllers
{
    public class BizTalkTokenController: object
    {
        readonly BizTalkTokenModel model = new BizTalkTokenModel();
        public BizTalkTokenController()
        {

        }
        
        public string GetBsid()
        {
            return model.BizTalkUserId;
        }

        public string GetPassword()
        {
            return model.BizTalkPassword;
        }

        public string GetExpire()
        {
            return model.BizTalkExpire;
        }

        public string GetResponseCode()
        {
            return model.ResponseCode;
        }

        public string GetResponseMessage()
        {
            return model.ResponseMessage;
        }

        public string GetToken()
        {
            return model.ResponseToken;
        }

        public string RefreshToken()
        {
            model.GenToken();
            return model.ResponseToken;
        }

    }
}
