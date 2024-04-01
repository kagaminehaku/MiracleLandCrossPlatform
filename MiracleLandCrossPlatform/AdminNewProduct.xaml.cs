using BUS;
using DTOCore;
namespace MiracleLandCrossPlatform;
using static MiracleLandCrossPlatform.CustomerShell;

public partial class AdminNewProduct : ContentPage
{
    private readonly UserAccount session;
    private string imagepath;
    public AdminNewProduct()
	{
		InitializeComponent();
        session = UserSession.CurrentUser;
    }

    private async void Addproduct_Clicked(object sender, EventArgs e)
    {
        if (imagepath != null)
        {
            if (!Int32.TryParse(ProductPrice.Text, out var price))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "The price is not valid.", "OK");
                return;
            }
            if (!Int32.TryParse(ProductQuantity.Text, out var quantity))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "The qty is not valid.", "OK");
                return;
            }
            if (ProductName.Text == null || ProductInfo == null || ProductPrice == null || ProductQuantity == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill in all field.", "OK");
                return;
            }
            var uploader = new ImgbbUploader();
            string imageUrl = await uploader.UploadImageAsync(imagepath);
            if (imageUrl == null) 
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Upload image error.", "OK");
                return ;
            }
            var busproduct = new BUSproduct();
            busproduct.AddNewProduct(ProductName.Text,price,quantity,ProductInfo.Text,imageUrl);
            await Application.Current.MainPage.DisplayAlert("Error", "New product is now ready to serve.", "OK");
            App.Current.MainPage = new AdminShell(session);
        }
        if (imagepath == null)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Please choose a product image.", "OK");
            AddImage();
        }
    }

    private async void AddImage()
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

    private void Insertimage_Clicked(object sender, EventArgs e)
    {
        AddImage();
    }
}