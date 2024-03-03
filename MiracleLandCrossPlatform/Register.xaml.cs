using DTOCore;
using BUS;
using System.Text.RegularExpressions;

namespace MiracleLandCrossPlatform;

public partial class Register : ContentPage
{
	public Register()
	{
		InitializeComponent();
	}
    private void Cancel_Click(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new MainPage());
    }

    private void register_btn_Click(object sender, EventArgs e)
    {
        RegisterBehavior();
    }

    private async void RegisterBehavior()
    {
        if (String.IsNullOrEmpty(register_username.Text) || String.IsNullOrEmpty(register_password.Text) || String.IsNullOrEmpty(register_password2.Text) || String.IsNullOrEmpty(register_email.Text) || String.IsNullOrEmpty(register_address.Text) || String.IsNullOrEmpty(register_phone.Text))
        {
            await DisplayAlert("Error","Please fill all empty fields.","OK");
            return;
        }

        if (register_password.Text != register_password2.Text)
        {
            await DisplayAlert("Error", "Password does not match.", "OK");
            return;
        }
        string username = register_username.Text;
        string password = register_password.Text;
        string type = "Normal";
        string email = register_email.Text;
        string address = register_address.Text;
        string phone = register_phone.Text;

        string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

        if (!Regex.IsMatch(email, emailPattern))
        {
            await DisplayAlert("Error", "Invaild email format.", "OK");
            return;
        }

        ResetRegisterData();

        BUSuser_account busUserAccount = new BUSuser_account();
        string result = busUserAccount.RegisterUser(username, password, type, email, phone, address);
        if (result == username)
        {
            await DisplayAlert("Success", "Register success!.", "OK");
            App.Current.MainPage = new NavigationPage(new MainPage());
        }
        else if (result == "Duplicate")
        {
            await DisplayAlert("Error", "Username has already taken.", "OK");
        }
        else
        {
            await DisplayAlert("Error", "Something SUS has occured.", "OK");
        }
    }

    private void ResetRegisterData()
    {
        register_username=null;
        register_password=null;
        register_email=null;
        register_address=null;
        register_phone=null;
    }
}