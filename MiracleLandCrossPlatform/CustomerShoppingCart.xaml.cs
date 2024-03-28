using BUS;
using DTOCore;
using MiracleLandCrossPlatform.ViewModel;
using static MiracleLandCrossPlatform.CustomerShell;

namespace MiracleLandCrossPlatform;

public partial class CustomerShoppingCart : ContentPage
{
    private ShoppingCartViewModel viewModel;
    private readonly UserAccount account;
    public CustomerShoppingCart()
	{
        InitializeComponent();
        viewModel = new ShoppingCartViewModel();
        account = UserSession.CurrentUser;
        InitializeData(account.Id);
    }

    private async void InitializeData(int userid)
    {
        await viewModel.LoadCartsAsync(userid);
        ProductListView.ItemsSource = viewModel.CartsItem;
    }

    private async void Buy_Button_Clicked(object sender, EventArgs e)
    {
        long total = 0;
        int count=0;
        foreach(Product item in ProductListView.ItemsSource)
        {
            count++;
        }
        if (count==0)
        {
            await DisplayAlert("Error", "Please buy something first", "OK");
            return;
        }
        foreach (Product item in ProductListView.ItemsSource)
        {
            total += item.Pprice * item.Pquantity;
        }
        if (count>0)
        {
            var busorders = new BUSorders();
            int oid = busorders.AddNewOrders(account.Id, total);
            foreach (Product item in ProductListView.ItemsSource)
            {
                var busproduct = new BUSproduct();
                busproduct.UpdateProductQuantityByName(item.Pname, item.Pquantity);
                var busorderdetail = new BUSorderdetail();
                int pid = busproduct.GetProductIdByName(item.Pname);
                bool isok = busorderdetail.AddNewOrderDetail(oid, pid, item.Pquantity);
                if (isok == false)
                {
                       await DisplayAlert("Error", "Something wrong", "OK");
                       return;
                }
            }
        }
        var buscart = new BUSshopping_cart();
        buscart.CartClear(account.Id);
        await DisplayAlert("Success", "Please pay"+total.ToString()+" when the package arrive", "OK");
        App.Current.MainPage = new CustomerShell(account);
    }

    private async void ProductListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var item = ProductListView.SelectedItem;
        Product product = item as Product;
        if (product != null)
        {
            var productcart = new BUSproduct();
            int vaildquantity = productcart.GetProductQuantityByName(product.Pname);
            int currentproductpid = productcart.GetProductIdByName(product.Pname);
            string quantityString = await Application.Current.MainPage.DisplayPromptAsync("Enter Quantity", "Please enter the quantity:", "OK", "Cancel", "0", -1, Keyboard.Numeric);

            if (int.TryParse(quantityString, out int quantity) && quantity <= vaildquantity)
            {
                var cart = new BUSshopping_cart();
                cart.UpdateQtyForShoppingCart(account.Id, currentproductpid, quantity);
                if(quantity > 0)
                {
                    await DisplayAlert("Success", "The qty has been changed", "OK");
                }
                if(quantity == 0)
                {
                    await DisplayAlert("Success", "The product has been removed from shopping cart", "OK");
                }
                App.Current.MainPage = new CustomerShell(account);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter vaild Quantity", "OK");
            }
        }
        ProductListView.SelectedItem = null;
    }
}