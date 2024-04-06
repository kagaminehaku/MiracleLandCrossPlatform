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

    private async void ProductListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var item = ProductListView.SelectedItem;
        Order orders = item as Order;
        if (orders != null)
        {
            await Shell.Current.GoToAsync($"{nameof(CustomerOrderDetail)}?{nameof(CustomerOrderDetail.orderid)}={orders.Orderid}");
        }
        ProductListView.SelectedItem = null;
    }
}