
using BUS;
using DTOCore;
namespace MiracleLandCrossPlatform;
[QueryProperty(nameof(pname), nameof(pname))]

public partial class AdminProductDetail : ContentPage
{
    private readonly UserAccount session;
    private Product productdetail;
    private string imagepath;
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

    private void EditProduct_Clicked(object sender, EventArgs e)
    {
        DeleteProduct.IsEnabled = false;
        SaveChanges.IsEnabled = true;
        ProductPrice.IsEnabled = true;
        ProductQuantity.IsEnabled = true;
        ProductInfo.IsEnabled = true;
        ChangeImage.IsEnabled = true;
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
                App.Current.MainPage = new AdminShell(session);
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

    private async void SaveChanges_Clicked(object sender, EventArgs e)
    {
        if (imagepath == null)
        {
            if (!Int32.TryParse(ProductPrice.Text, out var price))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "The price is not valid.", "OK");
            }
            if (!Int32.TryParse(ProductQuantity.Text, out var quantity))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "The qty is not valid.", "OK");
            }
            var busproduct = new BUSproduct();
            busproduct.EditProduct(productdetail.Pid, ProductName.Text, price, quantity, ProductInfo.Text, productdetail.Pimg);
            App.Current.MainPage = new AdminShell(session);
        }
        if (imagepath !=null)
        {
            if (!Int32.TryParse(ProductPrice.Text, out var price))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "The price is not valid.", "OK");
                return ;
            }
            if (!Int32.TryParse(ProductQuantity.Text, out var quantity))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "The qty is not valid.", "OK");
                return;
            }
            var uploader = new ImgbbUploader();
            string imageUrl = await uploader.UploadImageAsync(imagepath);
            if (imageUrl == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Upload image error.", "OK");
                return;
            }
            var busproduct = new BUSproduct();
            busproduct.EditProduct(productdetail.Pid, ProductName.Text, price, quantity, ProductInfo.Text, imageUrl);
            App.Current.MainPage = new AdminShell(session);
        }
    }

    private async void ChangeImage_Clicked(object sender, EventArgs e)
    {
        try
        {
            var file = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Select Image"
            });

            if (file != null)
            {
                imagepath = file.FullPath;
                ProductImage.Source = file.FullPath;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Alert", "No image selected.", "OK");
            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }
}