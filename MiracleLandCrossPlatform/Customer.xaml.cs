using DTOCore;
using BUS;
using MiracleLandCrossPlatform.ViewModel;
using static MiracleLandCrossPlatform.CustomerShell;

namespace MiracleLandCrossPlatform
{
    public partial class Customer : ContentPage
    {
        private ProductViewModel viewModel;
        private UserAccount account;

        public Customer()
        {
            InitializeComponent();
            viewModel = new ProductViewModel();
            InitializeData();
            account = UserSession.CurrentUser;
            UserInfo.Text = account.Username;
        }
        private async void InitializeData()
        {
            await viewModel.LoadProductsAsync();
            ProductListView.ItemsSource = viewModel.Products;
        }
    }
}
