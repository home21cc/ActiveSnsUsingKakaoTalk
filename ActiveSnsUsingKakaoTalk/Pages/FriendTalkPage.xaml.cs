using ActiveBaseLibrary;

using ActiveSnsUsingKakaoTalk.Models;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace ActiveSnsUsingKakaoTalk.Pages
{
    /// <summary>
    /// Interaction logic for TestPage.xaml
    /// </summary>
    public partial class FriendTalkPage : Window
    {
        readonly Setting setting = new Setting();
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
            KakaoTokenModel kakaoToken = new KakaoTokenModel(txtBsId.Text
                , txtPassword.Text
                , txtExpire.Text);
            var result = kakaoToken.GetToken();
            txtRCode.Text = (string)result.responseCode;
            txtToken.Text = (string)result.token;
        }

        private void SendFriendTalk_Click(object sender, RoutedEventArgs e)
        {
            // 1. 발송 대상이 여러명인지 확인
            // 2. 발송 대상 계정을 통하여 첨부파일 경로 찾기 
            // 3. FileName : 이름_사번_전화번호_카카오계정
            FriendTalk friend = new FriendTalk();

            string message = TBoxMessage.Text;
            int attCode = 0;
            string filePath = "이름_사번_전화번호_카카오계정.jpeg";
            //friend.SendFriendTalk(receipient, message, attCode, appUserId, userKey);
            friend.SendFriendTalk(message, attCode, filePath);
            
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
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
        }

    }
}
