using ActiveBaseLibrary;

using ActiveSnsUsingKakaoTalk.Models;

using System.Windows;

namespace ActiveSnsUsingKakaoTalk.Pages
{
    /// <summary>
    /// Interaction logic for TestPage.xaml
    /// </summary>
    public partial class FriendTalkPage : Window
    {
        Setting setting = new Setting();
        public FriendTalkPage()
        {
            InitializeComponent();
            UserInit();
        }
        private void UserInit()
        {
            txtBsId.Text = setting.GetDefaultValue("KakaoTalkId");
            txtPassword.Text = setting.GetDefaultValue("KakaoTalkPassword");
            txtExpire.Text = setting.GetDefaultValue("KakaoTalkExpire");
        }

        private void GetToken_Click(object sender, RoutedEventArgs e)
        {
            KakaoTokenModel kToken = new KakaoTokenModel();
            var result = kToken.GetToken(txtBsId.Text.ToString()
                , txtPassword.Text.ToString()
                , txtExpire.Text.ToString());
            txtRCode.Text = (string)result.responseCode;
            txtToken.Text = (string)result.token;
            txtMsg.Text = (string)result.msg;
        }

        private void SendFriendTalk_Click(object sender, RoutedEventArgs e)
        {
            FriendTalk friend = new FriendTalk();
            friend.SendFriendTalk();
        }
    }
}
