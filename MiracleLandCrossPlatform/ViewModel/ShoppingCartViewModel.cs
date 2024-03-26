using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DTOCore;
using BUS;

namespace MiracleLandCrossPlatform.ViewModel
{
    public class ShoppingCartViewModel
    {
        public ObservableCollection<Product> CartsItem { get; set; }

        public async Task LoadCartsAsync(int uid)
        {
            var cartproduct = new List<Product>();
            int cartid = 1;
            var shopping = new BUSshopping_cart();
            var cartlist = await shopping.GetAllCartItemsAsync(uid);
            foreach (ShoppingCart item in cartlist)
            {
                var busproduct = new BUSproduct();
                Product product = busproduct.GetProduct(item.Pid);
                product.Pid = cartid;
                product.Pprice = item.Pquantity * product.Pprice;
                product.Pquantity = item.Pquantity;
                cartid++;
                cartproduct.Add(product);
            }
            CartsItem = new ObservableCollection<Product>(cartproduct);
        }
    }
}
