using ActiveSnsUsingKakaoTalk.Pages;

using System;
using System.Windows;

namespace ActiveSnsUsingKakaoTalk
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Window
    {
        public StartPage()
        {
            InitializeComponent();
            UserInit();
        }

        private void UserInit()
        {
            this.ResizeMode = ResizeMode.NoResize;
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeigth = System.Windows.SystemParameters.PrimaryScreenHeight;
            this.Left = (screenWidth / 2) - (this.Width / 2);
            this.Top = (screenHeigth / 2) - (this.Height / 2);
            GridHeader.Style = FindResource("StyleBodyGrid") as Style;
            GridCommand.Style = FindResource("StyleBodyGrid") as Style;
            PbPassword.Style = FindResource("StylePassword") as Style;
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            FriendTalkPage tPage = new FriendTalkPage();
            tPage.Show();
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            this.Close();
        }

        private void BtnSetting_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
