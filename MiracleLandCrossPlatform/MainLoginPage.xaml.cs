using BUS;
using DTOCore;
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



        private void RegisterClick (object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }

        private async void AdminBehavior(UserAccount user)
        {
            await DisplayAlert("Login success !", $"Welcome {user.Username}", "OK");
            App.Current.MainPage = new NavigationPage(new AdminControlPanel(user));
            LoginBtn.IsEnabled=true;
        }

        private async void CustomerBehavior(UserAccount user)
        {
            await DisplayAlert("Login success !", $"Welcome {user.Username}", "OK");
            //App.Current.MainPage = new NavigationPage(new Customer(user));
            App.Current.MainPage = new CustomerShell(user);
            LoginBtn.IsEnabled = true;
        }

        private void GuestBehavior(UserAccount user)
        {

        }


        private void ResetLoginData()
        {
            UsernameTextBox=null;
            PasswordTextBox=null;
        }

        private void Guest_Click(object sender, EventArgs e)
        {
           //GuestBehavior(null);
        }
    }

}
