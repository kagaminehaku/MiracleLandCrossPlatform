using BUS;
using DTOCore;
using System.Collections.ObjectModel;
namespace MiracleLandCrossPlatform;

public partial class AdminControlPanel : ContentPage
{
    public ObservableCollection<Product> Products { get; set; }
    private UserAccount session;
    public AdminControlPanel()
	{
		InitializeComponent();
        InitializeTestData();
        BindingContext = this;
    }

    private void InitializeTestData()
    {
        Products = new ObservableCollection<Product>
            {
                new Product { Pid = 1, Pname = "Product 1", Pprice = 5, Pquantity = 100, Pinfo = "Info about Product 1", Pimg = "https://cdn.discordapp.com/attachments/1212428754446590033/1212428999263780924/Csharp_Logo.png?ex=65f1cd7f&is=65df587f&hm=be8972ccc9e91a5f09e88cf266fc5b45e2c0decc888f6982490bb1c341e44324&" },
                new Product { Pid = 2, Pname = "Product 2", Pprice = 68, Pquantity = 50, Pinfo = "Info about Product 2", Pimg = "https://cdn.discordapp.com/attachments/1212428754446590033/1212428999263780924/Csharp_Logo.png?ex=65f1cd7f&is=65df587f&hm=be8972ccc9e91a5f09e88cf266fc5b45e2c0decc888f6982490bb1c341e44324&" },
                new Product { Pid = 3, Pname = "Product 3", Pprice = 7, Pquantity = 200, Pinfo = "Info about Product 3", Pimg = "https://cdn.discordapp.com/attachments/1212428754446590033/1212428999263780924/Csharp_Logo.png?ex=65f1cd7f&is=65df587f&hm=be8972ccc9e91a5f09e88cf266fc5b45e2c0decc888f6982490bb1c341e44324&" }
            };
    }
}