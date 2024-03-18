using DTOCore;
using MiracleLandCrossPlatform.ViewModel;

namespace MiracleLandCrossPlatform
{
    public partial class AdminControlPanel : ContentPage
    {
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
