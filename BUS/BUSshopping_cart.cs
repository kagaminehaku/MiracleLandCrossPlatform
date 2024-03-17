using DAL;
using DTOCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUSshopping_cart
    {
        public List<ShoppingCart> GetAllItemInUserCart(int uid)
        {
            var Cart = new DALshopping_cart();
            return Cart.GetAllItemInUserCart(uid);
        }

        public void DeleteCartItem (int uid,int pid) 
        {
            var cart = new DALshopping_cart();
            cart.DeleteItemInCart(uid, pid);
        }

        public void AddItemToCart(int uid, int pid, int qty) 
        {
            var cart = new DALshopping_cart();
            cart.AddItemToCart(uid, pid, qty);
        }

        public void UpdateQty (int uid ,int pid, int qty) 
        {
            if (qty > 0)
            {
                var cart = new DALshopping_cart();
                cart.UpdateAddItemQtyInCart(uid, pid, qty);
            }
            else if (qty <= 0)
            {
                DeleteCartItem(uid, pid);
            }
        }

        public void EditItemQtyInCart(int uid, int pid, int newqty)
        {
            var cart = new DALshopping_cart();
            cart.EditItemQtyInCart (uid, pid, newqty);
        }


    }
}
