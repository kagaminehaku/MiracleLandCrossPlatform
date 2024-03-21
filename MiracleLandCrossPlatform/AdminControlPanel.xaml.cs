using DTOCore;
using MiracleLandCrossPlatform.ViewModel;

namespace MiracleLandCrossPlatform
{
    public partial class AdminControlPanel : ContentPage
    {
        private ProductViewModel viewModel;
        private UserAccount session;

        public AdminControlPanel()
        {
            InitializeComponent();
            viewModel = new ProductViewModel();
            InitializeData();
        }

        private async void InitializeData()
        {
            await viewModel.LoadProductsAsync();

            ProductListView.ItemsSource = viewModel.Products;
        }
    }
}
