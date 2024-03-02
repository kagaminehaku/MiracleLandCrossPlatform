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

        private void Login(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string userpwd = PasswordTextBox.Text;
            if (username == null || userpwd == null )  
            {
                DisplayAlert("Error !", "Username and password cannot be blank.", "OK");
                return; 
            }
            var bLogin = new BUSLogin();

            UserAccount user = bLogin.checkValidLogin(username, userpwd);

            ResetLoginData();
            if (user == null)
            {
                DisplayAlert("Error !", "Invalid username or password.", "OK");
            }
            else if (user.Type == "admin")
            {
                
                AdminBehavior(user);
            }
            else if (user.Type == "Normal")
            {
                //CustomerBehavior(user);
            }
        }

        private void RegisterClick (object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }

        private void AdminBehavior(UserAccount user)
        {
            //MessageBox.Show($"Welcome {user.Username}!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DisplayAlert("Success !", $"Welcome {user.Username}", "OK");
            //var miracleLandAdminUI = new MiracleLandAdminUI(user);
            //Navigation.PushAsync(new AdminControlPanel());
            Navigation.PushAsync(new AdminControlPanel());
            //miracleLandAdminUI.FormClosed += (s, args) => this.Show();
            //miracleLandAdminUI.Show();
            //this.Hide();
        }

        private void CustomerBehavior(UserAccount user)
        {
            //MessageBox.Show($"Welcome {user.Username}!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //var miracleLandMainUI = new MiracleLandMainUI(user);
            //miracleLandMainUI.FormClosed += (s, args) => this.Show();
            //miracleLandMainUI.Show();
            //this.Hide();
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
