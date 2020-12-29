using ActiveBaseLibrary;

using ActiveCommonLibrary;

using ActiveSnsUsingKakaoTalk.Controllers;

using System;
using System.Windows;
using System.Windows.Threading;

namespace ActiveSnsUsingKakaoTalk.Pages
{
    /// <summary>
    /// Interaction logic for TestPage.xaml
    /// </summary>
    public partial class FriendTalkPage : Window
    {
        readonly DispatcherTimer timer = new DispatcherTimer();
        readonly BizTalkTokenController tokenController = new BizTalkTokenController();
        readonly BizTalkFriendController friendController = new BizTalkFriendController();
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

            txtBsId.Text = tokenController.GetBsid();
            txtPassword.Text = tokenController.GetPassword();
            txtExpire.Text = tokenController.GetExpire();
            txtToken.Text = tokenController.GetToken();
            txtRCode.Text = tokenController.GetResponseCode();


            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(ExpireTimer_Tick);
            timer.Start();
        }

        private void ExpireTimer_Tick(object sender, EventArgs e)
        {
            int expireTime = Int32.Parse(txtExpire.Text);
            expireTime -= 1;
            txtExpire.Text = (expireTime).ToString();

            if (BtnSendFriendTalk.IsEnabled == true && expireTime <= 0)
                BtnSendFriendTalk.IsEnabled = false;
        }


        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            if (timer != null)
            {
                timer.Stop();
            }
            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            this.Close();
        }

        private void BtnReConnect_Click(object sender, RoutedEventArgs e)
        {
            tokenController.RefreshToken();
            txtBsId.Text = tokenController.GetBsid();
            txtPassword.Text = tokenController.GetPassword();
            txtExpire.Text = tokenController.GetExpire();
            txtToken.Text = tokenController.GetToken();
            txtRCode.Text = tokenController.GetResponseCode();
            BtnSendFriendTalk.IsEnabled = true;
        }

        private void BtnSendFriendTalk_Click(object sender, RoutedEventArgs e)
        {
            var x = friendController.SendFriendTalk(BizTalkKeyType.AppUserIdKey, "01045512319", "TestTitle", "TestMessage", 0, "Testfile.jpg");
            txtRCode.Text = friendController.GetResponseCode();
        }
    }
}
