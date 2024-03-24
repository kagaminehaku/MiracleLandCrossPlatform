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
        public ObservableCollection<ShoppingCart> CartsItem { get; set; }

        public async Task LoadCartsAsync(int uid)
        {
            var shopping = new BUSshopping_cart();
            var cartlist = await shopping.GetAllCartItemsAsync(uid);
            CartsItem = new ObservableCollection<ShoppingCart>(cartlist);
        }
    }
}
