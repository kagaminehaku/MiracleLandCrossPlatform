using DTOCore;
using BUS;
using static MiracleLandCrossPlatform.CustomerShell;

namespace MiracleLandCrossPlatform;

public partial class CustomerPassword : ContentPage
{
    private UserAccount session;
	public CustomerPassword()
	{
		InitializeComponent();
        session = UserSession.CurrentUser;
    }

    private async void OnChangePasswordClicked(object sender, EventArgs e)
    {
        if (NewPasswordEntry.Text != ConfirmPasswordEntry.Text || String.IsNullOrEmpty(NewPasswordEntry.Text) || String.IsNullOrEmpty(ConfirmPasswordEntry.Text) || String.IsNullOrEmpty(CurrentPasswordEntry.Text))
            {
                await DisplayAlert("Error","Please fill in all field.","OK");
                return;
            }
            var bususeraccount = new BUSuser_account();
            if (bususeraccount.IsPasswordVaild(NewPasswordEntry.Text) == false)
            {
                await DisplayAlert("Error", "Password does not match.", "OK");
                return;
            }
            var buslogin = new BUSLogin();
            var allowchangepwd = (buslogin.checkValidLogin(session.Username.ToString(), CurrentPasswordEntry.Text));
            if (allowchangepwd != null)
            {
                var bus2useraccount = new BUSuser_account();
                if (bus2useraccount.UpdatePassword(session.Username.ToString(), NewPasswordEntry.Text))
                {
                    await DisplayAlert("Success", "Session is now expired.", "OK");
                    session = null;
                    App.Current.MainPage = new MainPage();
                }
                else
                {
                await DisplayAlert("Error", "Something sus happened", "OK");
                return;
                }
            }
            else if (allowchangepwd == null)
            {
            await DisplayAlert("Error", "Old password is invaild.", "OK");
            return;
            }
    }
}