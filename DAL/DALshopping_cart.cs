using DTOCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace DAL
{
    public class DALshopping_cart
    {
        public List<ShoppingCart> GetAllItemInUserCart(int uid) 
        {
            using (var dbContext = new TsmgContext())
            {
                return dbContext.ShoppingCarts.Where(cart => cart.Id == uid).ToList();
            }
        }

        public async Task<List<ShoppingCart>> GetAllItemInUserCartAsync(int uid)
        {
            using (var dbContext = new TsmgContext())
            {
                return await dbContext.ShoppingCarts.Where(cart => cart.Id == uid).ToListAsync();
            }
        }

        public ShoppingCart GetExistCartItem(int uid, int pid)
        {
            using (var dbContext = new TsmgContext())
            {
                return dbContext.ShoppingCarts.FirstOrDefault(cart => cart.Id == uid && cart.Pid == pid);
            }
        }

        public async void UpdateAddItemQtyInCart(int uid, int pid ,int newqty)
        {
            try
            {
                using (var dbContext = new TsmgContext())
                {
                    var CartItem = dbContext.ShoppingCarts.FirstOrDefault(cart => cart.Id == uid && cart.Pid == pid);
                    CartItem.Pquantity = CartItem.Pquantity+newqty;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        public async void UpdateAddItemQtyInShoppingCart(int uid, int pid, int newqty)
        {
            try
            {
                using (var dbContext = new TsmgContext())
                {
                    var CartItem = dbContext.ShoppingCarts.FirstOrDefault(cart => cart.Id == uid && cart.Pid == pid);
                    CartItem.Pquantity = newqty;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        public void EditItemQtyInCart(int uid, int pid, int newqty)
        {
            try
            {
                using (var dbContext = new TsmgContext())
                {
                    var CartItem = dbContext.ShoppingCarts.FirstOrDefault(cart => cart.Id == uid && cart.Pid == pid);
                    CartItem.Pquantity =newqty;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void DeleteItemInCart (int uid, int pid)
        {
            try
            {
                using (var dbContext = new TsmgContext())
                {
                    var CartItem = dbContext.ShoppingCarts.FirstOrDefault(cart => cart.Id == uid && cart.Pid == pid);
                    dbContext.ShoppingCarts.Remove(CartItem);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void AddItemToCart (int uid ,int pid ,int newqty)
        {
            try
            {
                using (var dbContext = new TsmgContext())
                {
                    var existingItem = GetExistCartItem(uid,pid);
                    if (existingItem != null)
                    {
                        UpdateAddItemQtyInCart (uid, pid , newqty);
                    }
                    if (existingItem == null)
                    {
                        var CartItem = new ShoppingCart
                        {
                            Id = uid,
                            Pid = pid,
                            Pquantity = newqty
                        };
                        dbContext.ShoppingCarts.Add(CartItem);
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
             
    }
}
