namespace MiracleLandCrossPlatform
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void Login(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminControlPanel());
        }
    }

}
