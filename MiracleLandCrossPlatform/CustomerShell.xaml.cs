using DTOCore;
namespace MiracleLandCrossPlatform
{
    public partial class CustomerShell : Shell
    {
        public CustomerShell(UserAccount user)
        {
            UserSession.CurrentUser = user;
            InitializeComponent();
            Routing.RegisterRoute(nameof(ProductDetail), typeof(ProductDetail));
        }
        public static class UserSession
        {
            public static UserAccount CurrentUser { get; set; }
        }

    }
}
