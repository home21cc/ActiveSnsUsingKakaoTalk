using ActiveBaseLibrary;
using ActiveSnsUsingKakaoTalk.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace ActiveSnsUsingKakaoTalk.Pages
{
    /// <summary>
    /// Interaction logic for TestPage.xaml
    /// </summary>
    public partial class FriendTalkPage : Window
    {
        readonly Setting setting = new Setting();
        DispatcherTimer timer = new DispatcherTimer();
        public FriendTalkPage()
        {
            InitializeComponent();
            UserInit();
        }
        private void UserInit()
        {
            BorderConnectInfo.Style = FindResource("StyleBorder") as Style;
            BorderContentInfo.Style = FindResource("StyleBorder") as Style;
            GridConnect.Style = FindResource("StyleGrayGrid") as Style;
            GridMessage.Style = FindResource("StyleGrayGrid") as Style;
            LblConnect.Style = FindResource("StyleBoldLabel") as Style;
            LblMessage.Style = FindResource("StyleBoldLabel") as Style;

            txtBsId.Text = setting.GetDefaultValue("KakaoTalkId");
            txtPassword.Text = setting.GetDefaultValue("KakaoTalkPassword");
            txtExpire.Text = (Int32.Parse(setting.GetDefaultValue("KakaoTalkExpire")) * 60).ToString();
            KakaoTokenModel kakaoToken = new KakaoTokenModel(txtBsId.Text
                , txtPassword.Text
                , txtExpire.Text);
            var result = kakaoToken.GetToken();
            txtRCode.Text = (string)result.responseCode;
            txtToken.Text = (string)result.token;

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(ExpireTimer_Tick);
            timer.Start();
        }

        private void ExpireTimer_Tick(object sender, EventArgs e)
        {
            int expireTime = Int32.Parse(txtExpire.Text);
            expireTime -= 1;
            txtExpire.Text = (expireTime).ToString();
        }

        private void SendFriendTalk_Click(object sender, RoutedEventArgs e)
        {
            FriendTalk friend = new FriendTalk();
            string message = TBoxMessage.Text;
            int attCode = 0;
            string filePath = "이름_사번_전화번호_카카오계정.jpeg";
            friend.SendFriendTalk(message, attCode, filePath);            
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            if(timer != null)
            {
                timer.Stop();
            }
            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            this.Close();
        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            KakaoTokenModel kToken = new KakaoTokenModel();
            var result = kToken.GetToken(txtBsId.Text.ToString()
                , txtPassword.Text.ToString()
                , txtExpire.Text.ToString());
            txtRCode.Text = (string)result.responseCode;
            txtToken.Text = (string)result.token;
            txtExpire.Text = (Int32.Parse(setting.GetDefaultValue("KakaoTalkExpire")) * 60).ToString();
        }
    }
}
