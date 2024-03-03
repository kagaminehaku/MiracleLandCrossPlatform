using BUS;
using DTOCore;
using MiracleLandCrossPlatform.ViewModel;
using System.Collections.ObjectModel;

namespace MiracleLandCrossPlatform
{
    public partial class AdminControlPanel : ContentPage
    {
        public ObservableCollection<Product> Products { get; set; }
        private ProductViewModel viewModel;

        public AdminControlPanel()
        {
            InitializeComponent();
            viewModel = new ProductViewModel();
            InitializeTestData();
        }

        private async void InitializeTestData()
        {
            await viewModel.LoadProductsAsync();

            ProductListView.ItemsSource = viewModel.Products;
        }
    }
}
