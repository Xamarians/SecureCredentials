using System;
using Xamarin.Forms;

namespace SecureCredentials
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnStoreCredsClicked(object sender, EventArgs e)
        {
            // SAMPLE DATA
            var username = "Xamarians";
            var userId = "a1er3tttdvd";
            var token = "sgfcuwebguyegergu4e-rb8gguy4re8g74re94949372723jsdbjshdbvjerb";

            if (!string.IsNullOrWhiteSpace(usernameEntry.Text))
                username = usernameEntry.Text;

            if (!string.IsNullOrWhiteSpace(userIdEntry.Text))
                userId = userIdEntry.Text;

            if (!string.IsNullOrWhiteSpace(tokenEntry.Text))
                token = tokenEntry.Text;

            //Set Username
            DependencyService.Get<ISecuredPreference>().SetValue(Constants.UserNameKey, username);

            //Set UserId
            DependencyService.Get<ISecuredPreference>().SetValue(Constants.UserIdKey, userId);

            //Set Token
            DependencyService.Get<ISecuredPreference>().SetSecuredValue(Constants.TokenKey, token);
        }

        private void OnGetUserNameClicked(object sender, EventArgs e)
        {
            //Get Username
           var username = DependencyService.Get<ISecuredPreference>().GetValue(Constants.UserNameKey);

            //Display Username
           DisplayAlert("Details", username, "OK");
        }

        private void OnGetUserIdClicked(object sender, EventArgs e)
        {
            //Get UserId
            var userId = DependencyService.Get<ISecuredPreference>().GetValue(Constants.UserIdKey);

            //Display UserId
            DisplayAlert("Details", userId, "OK");
        }

        private void OnGetTokenClicked(object sender, EventArgs e)
        {
            //Get Token
            var token = DependencyService.Get<ISecuredPreference>().GetSecuredValue(Constants.TokenKey);

            //Display Token
            DisplayAlert("Details", token, "OK");
        }

    }
}
