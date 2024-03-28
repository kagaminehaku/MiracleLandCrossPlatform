
using BUS;
using DTOCore;
using static MiracleLandCrossPlatform.CustomerShell;
namespace MiracleLandCrossPlatform;
[QueryProperty(nameof(pname), nameof(pname))]

public partial class AdminProductDetail : ContentPage
{
    private readonly UserAccount session;
    private Product productdetail;
    public string pname
    {
        set { LoadProduct(value); }
    }
    public AdminProductDetail()
	{
		InitializeComponent();
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

    private async void EditProduct_Clicked(object sender, EventArgs e)
    {
        DeleteProduct.IsEnabled = false;
        SaveChanges.IsEnabled = true;
        ProductPrice.IsEnabled = true;
        ProductQuantity.IsEnabled = true;
        ProductInfo.IsEnabled = true;
    }

    private async void DeleteProduct_Clicked(object sender, EventArgs e)
    {
        string productNameToDelete = await Application.Current.MainPage.DisplayPromptAsync("Delete Product", "Enter the name of the product to delete:", "OK", "Cancel", "", -1, Keyboard.Default);

        if (!string.IsNullOrWhiteSpace(productNameToDelete))
        {
           
            if (productNameToDelete == productdetail.Pname)
            {
                var productAdmin = new BUSproduct();
                productAdmin.RemoveProductByName(productNameToDelete);
                App.Current.MainPage = new CustomerShell(session);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "The entered product name does not match the product to be deleted.", "OK");
                return;
            }
        }
        else
        {
            return;
        }
    }

    private void SaveChanges_Clicked(object sender, EventArgs e)
    {

    }
}