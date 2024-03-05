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

        //private void Login(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new AdminControlPanel());
        //}

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
            var bLogin = new BUSLogin();
            UserAccount user = bLogin.checkValidLogin(username, userpwd);

            if (user == null)
                {
                    await DisplayAlert("Error !", "Invalid username or password.", "OK");
                    LoginBtn.IsEnabled = true;
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
            //MessageBox.Show($"Welcome {user.Username}!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await DisplayAlert("Login success !", $"Welcome {user.Username}", "OK");
            //var miracleLandAdminUI = new MiracleLandAdminUI(user);
            //Navigation.PushAsync(new AdminControlPanel());
            //await Navigation.PushAsync(new AdminControlPanel());
            App.Current.MainPage = new NavigationPage(new AdminControlPanel());
            LoginBtn.IsEnabled=true;
            //miracleLandAdminUI.FormClosed += (s, args) => this.Show();
            //miracleLandAdminUI.Show();
            //this.Hide();
        }

        private async void CustomerBehavior(UserAccount user)
        {
            //MessageBox.Show($"Welcome {user.Username}!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //await DisplayAlert("Login success !", $"Welcome {user.Username}", "OK");
            //var miracleLandMainUI = new MiracleLandMainUI(user);
            //await Navigation.PushAsync(new NewContent1());
            //LoginBtn.IsEnabled = true;
            //miracleLandMainUI.FormClosed += (s, args) => this.Show();
            //miracleLandMainUI.Show();
            //this.Hide();

            // Show a success message after navigation
            await DisplayAlert("Login success !", $"Welcome {user.Username}", "OK");

            // Enable the login button
            LoginBtn.IsEnabled = true;
        }

        private void GuestBehavior(UserAccount user)
        {
            //var miracleLandMainUI = new MiracleLandMainUI(null);
            //miracleLandMainUI.FormClosed += (s, args) => this.Show();
            //miracleLandMainUI.Show();
            //this.Hide();
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
