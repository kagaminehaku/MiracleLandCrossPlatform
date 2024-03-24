using DTOCore;
using MiracleLandCrossPlatform.ViewModel;
using static MiracleLandCrossPlatform.CustomerShell;

namespace MiracleLandCrossPlatform;

public partial class CustomerShoppingCart : ContentPage
{
    private ShoppingCartViewModel viewModel;
    private readonly UserAccount account;
    public CustomerShoppingCart()
	{
        InitializeComponent();
        viewModel = new ShoppingCartViewModel();
        account = UserSession.CurrentUser;
        InitializeData(account.Id);
    }

    private async void InitializeData(int userid)
    {
        await viewModel.LoadCartsAsync(userid);
        ProductListView.ItemsSource = viewModel.CartsItem;
    }
}