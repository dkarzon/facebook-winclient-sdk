using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Facebook.Client;

namespace BasicApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
        }

        private void loginViaWebview_Click(object sender, RoutedEventArgs e)
        {
            Session.ActiveSession.LoginWithBehavior("email,public_profile,user_friends", FacebookLoginBehavior.LoginBehaviorWebViewOnly);
        }

        private void showDialogButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> friendsList = new List<String>();
            friendsList.Add("9074");
            friendsList.Add("535949260");
            Session.ShowAppRequestsDialog(null, "What's up", null);
        }

        private const string key = "FACEBOOK_SESSION";

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            var settings = ApplicationData.Current.LocalSettings;
            if (!settings.Values.ContainsKey(key))
                return;
            settings.Values.Remove(key);

            Session.ActiveSession.Logout();

            if (!settings.Values.ContainsKey(key)) 
                return;
            settings.Values.Remove(key);
        }
    }
}
