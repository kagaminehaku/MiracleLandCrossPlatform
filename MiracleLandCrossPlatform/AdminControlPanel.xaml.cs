using DTOCore;
using MiracleLandCrossPlatform.ViewModel;

namespace MiracleLandCrossPlatform
{
    public partial class AdminControlPanel : ContentPage
    {
        private ProductViewModel viewModel;

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

        private async void ProductListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = ProductListView.SelectedItem;
            Product product = item as Product;
            if (product != null)
            {
                await Shell.Current.GoToAsync($"{nameof(AdminProductDetail)}?{nameof(AdminProductDetail.pname)}={product.Pname}");
            }
            ProductListView.SelectedItem = null;
        }
    }
}
