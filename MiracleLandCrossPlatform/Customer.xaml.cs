using DTOCore;

namespace MiracleLandCrossPlatform;

public partial class Customer : ContentPage
{
	private UserAccount session;
	public Customer(UserAccount user)
	{
		InitializeComponent();
		session = user;
	}
}