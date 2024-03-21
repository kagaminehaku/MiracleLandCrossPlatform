using DTOCore;
namespace MiracleLandCrossPlatform;

public partial class AdminProductEditPage : ContentPage
{
	private Product Editproduct;
	public AdminProductEditPage(Product product)
	{
		Editproduct = product;
		InitializeComponent();
		InitializeProduct();
	}

	private void InitializeProduct ()
	{
		ProductView.Text = Editproduct.Pname;
	}
}