using DTOCore;
using MiracleLandCrossPlatform.ViewModel;
using static MiracleLandCrossPlatform.CustomerShell;

namespace MiracleLandCrossPlatform
{
    public partial class Customer : ContentPage
    {
        private ProductViewModel viewModel;
        private readonly UserAccount account;

        public Customer()
        {
            InitializeComponent();
            viewModel = new ProductViewModel();
            InitializeData();
            account = UserSession.CurrentUser;
        }
        private async void InitializeData()
        {
            await viewModel.LoadProductsAsync();
            ProductListView.ItemsSource = viewModel.Products;
        }

        private async void ProductListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = ProductListView.SelectedItem;
            Product product = item as Product;
            if (product != null)
            {
                await DisplayAlert("LMAO", product.Pname.ToString(), "OK");
                await Shell.Current.GoToAsync($"{nameof(ProductDetail)}?{nameof(ProductDetail.pname)}={product.Pname}");
            }
            ProductListView.SelectedItem = null;
        }
    }
}
