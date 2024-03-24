
using BUS;

namespace MiracleLandCrossPlatform;
[QueryProperty(nameof(pname), nameof(pname))]
public partial class ProductDetail : ContentPage
{
    public string pname
    {
        set { LoadProduct(value); }
    }
    public ProductDetail()
	{
		InitializeComponent();
	}

    private void LoadProduct(string pname)
    {
        var bUSproduct = new BUSproduct();
        var product = bUSproduct.GetProductByName(pname);
        ProductName.Text = product.Pname;
        BindingContext = product;
    }
}