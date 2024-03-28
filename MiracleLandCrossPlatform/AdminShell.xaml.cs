using DTOCore;
namespace MiracleLandCrossPlatform;

public partial class AdminShell : Shell
{
	public AdminShell(UserAccount user)
	{
        UserSession.CurrentUser = user;
        InitializeComponent();
        Routing.RegisterRoute(nameof(AdminProductDetail), typeof(AdminProductDetail));
    }
    public static class UserSession
    {
        public static UserAccount CurrentUser { get; set; }
    }
}