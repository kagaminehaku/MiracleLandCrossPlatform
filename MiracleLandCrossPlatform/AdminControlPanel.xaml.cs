using BUS;
using DTOCore;
using Microsoft.IdentityModel.Tokens;
using MiracleLandCrossPlatform.ViewModel;
using System.Collections.ObjectModel;

namespace MiracleLandCrossPlatform
{
    public partial class AdminControlPanel : ContentPage
    {
        public ObservableCollection<Product> Products { get; set; }
        private ProductViewModel viewModel;
        private UserAccount session;

        public AdminControlPanel(UserAccount user)
        {
            InitializeComponent();
            viewModel = new ProductViewModel();
            InitializeData();
            session = user;
        }

        private async void InitializeData()
        {
            await viewModel.LoadProductsAsync();

            ProductListView.ItemsSource = viewModel.Products;
        }
    }
}
