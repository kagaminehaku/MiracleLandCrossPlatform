
using BUS;
using DTOCore;
using static MiracleLandCrossPlatform.CustomerShell;
namespace MiracleLandCrossPlatform;
[QueryProperty(nameof(pname), nameof(pname))]
public partial class ProductDetail : ContentPage
{
    private readonly UserAccount account;
    private Product productdetail;
    public string pname
    {
        set { LoadProduct(value); }
    }
    public ProductDetail()
	{
		InitializeComponent();
        account = UserSession.CurrentUser;
    }

    private void LoadProduct(string pname)
    {
        var bUSproduct = new BUSproduct();
        var product = bUSproduct.GetProductByName(pname);
        ProductImage.Source = product.Pimg;
        ProductName.Text = product.Pname;
        ProductPrice.Text = product.Pprice.ToString();
        ProductQuantity.Text = product.Pquantity.ToString();
        ProductInfo.Text = product.Pinfo;
        productdetail = product;
        BindingContext = product;
    }

    private async void AddToCart_Clicked(object sender, EventArgs e)
    {
        string quantityString = await Application.Current.MainPage.DisplayPromptAsync("Enter Quantity", "Please enter the quantity:", "OK", "Cancel", "0", -1, Keyboard.Numeric);

        if (int.TryParse(quantityString, out int quantity)&& quantity <= productdetail.Pquantity)
        {
            await Application.Current.MainPage.DisplayAlert("Quantity Entered", $"Quantity: {quantity}", "OK");
            var cart = new BUSshopping_cart();
            cart.AddItemToCart(account.Id,productdetail.Pid,quantity);
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Please enter vaild Quantity", "OK");
        }
    }
}