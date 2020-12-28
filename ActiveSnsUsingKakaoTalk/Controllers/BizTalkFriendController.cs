using ActiveBaseLibrary;

using ActiveSnsUsingKakaoTalk.Models;

using System.Collections.Generic;

namespace ActiveSnsUsingKakaoTalk.Controllers
{
    public class BizTalkFriendController : object
    {
        readonly BizTalkFriendModel friendModel = new BizTalkFriendModel();
        public BizTalkFriendController()
        {

        }


        // 메시지 전송
        public FriendResponseData SendFriendTalk(BizTalkKeyType keyType, string keyValue, string msgTitle, string msgBody, int attCode, string filePath)
        {
            return friendModel.SendFriendTalk(keyType, keyValue, msgTitle, msgBody, attCode, filePath);
        }

        // 메시지 일괄 전송
        public List<FriendResponseData> SendFriendTalk(BizTalkKeyType keyType, List<string> keyValues, string msgTitle, string msgBody, int attCode, string filePath )
        {
            List<FriendResponseData> result = new List<FriendResponseData>();
            foreach(var item in keyValues)
            {
                result.Add(friendModel.SendFriendTalk(keyType, item, msgTitle, msgBody, attCode, filePath));
            }
            return result;
        }

        public string GetResponseCode()
        {
            return null;
        }
    }
}
