using BUS;
using DTOCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MiracleLandCrossPlatform.ViewModel;
using static MiracleLandCrossPlatform.CustomerShell;

namespace MiracleLandCrossPlatform;
[QueryProperty(nameof(orderid), nameof(orderid))]
public partial class CustomerOrderDetail : ContentPage
{
    private OrderDetailView viewModel;
    private readonly UserAccount account;
    public int orderid
    {
        set { InitializeData(value); }
    }
    public CustomerOrderDetail()
	{
        InitializeComponent();
        viewModel = new OrderDetailView();
        account = UserSession.CurrentUser;
    }

    private async void InitializeData(int userid)
    {
        await viewModel.LoadOrderDetailAsync(userid);
        ProductListView.ItemsSource = viewModel.OrderDetail;
    }

}