using DTOCore;
using MiracleLandCrossPlatform.ViewModel;
using static MiracleLandCrossPlatform.CustomerShell;

namespace MiracleLandCrossPlatform;

public partial class CustomerOrders : ContentPage
{
    private OrdersView viewModel;
    private readonly UserAccount account;
    public CustomerOrders()
	{
        InitializeComponent();
        account = UserSession.CurrentUser;
        viewModel = new OrdersView();
        InitializeData();
    }

    private async void InitializeData()
    {
        await viewModel.LoadOrderAsync(account.Id);
        ProductListView.ItemsSource = viewModel.Order;
    }

    private void ProductListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }
}