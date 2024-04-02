using BUS;
using DTOCore;
using System.Net.NetworkInformation;
namespace MiracleLandCrossPlatform
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Login(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string userpwd = PasswordTextBox.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(userpwd))
            {
                await DisplayAlert("Error !", "Username and password cannot be blank.", "OK");
                return;
            }
            LoginBtn.IsEnabled = false;
            RegisterBtn.IsEnabled = false;
            var bLogin = new BUSLogin();
            UserAccount user = bLogin.checkValidLogin(username, userpwd);

            if (user == null)
                {
                    await DisplayAlert("Error !", "Invalid username or password.", "OK");
                    LoginBtn.IsEnabled = true;
                    RegisterBtn.IsEnabled = true;
            }
            else if (user.Type == "admin")
                {
                    AdminBehavior(user);

            }
            else if (user.Type == "Normal")
                {
                    CustomerBehavior(user);
                }

        }

        private async void RegisterClick (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }

        private async void AdminBehavior(UserAccount user)
        {
            await DisplayAlert("Login success !", $"Welcome {user.Username}", "OK");
            App.Current.MainPage = new AdminShell(user);
            LoginBtn.IsEnabled = true;
            RegisterBtn.IsEnabled = true;
        }

        private async void CustomerBehavior(UserAccount user)
        {
            await DisplayAlert("Login success !", $"Welcome {user.Username}", "OK");
            //App.Current.MainPage = new NavigationPage(new Customer(user));
            App.Current.MainPage = new CustomerShell(user);
            LoginBtn.IsEnabled = true;
            RegisterBtn.IsEnabled = true;
        }

        private void ResetLoginData()
        {
            UsernameTextBox=null;
            PasswordTextBox=null;
        }

    }

}
