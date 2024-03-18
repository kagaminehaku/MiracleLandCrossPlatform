using DTOCore;
using BUS;
using MiracleLandCrossPlatform.ViewModel;

namespace MiracleLandCrossPlatform;

public partial class Customer : ContentPage
{
    private ProductViewModel viewModel;
    private UserAccount session;
	public Customer(UserAccount user)
	{
		InitializeComponent();
        viewModel = new ProductViewModel();
        session = user;
		InitializeData();
	}

    private async void InitializeData()
    {
        await viewModel.LoadProductsAsync();

        ProductListView.ItemsSource = viewModel.Products;
    }
}