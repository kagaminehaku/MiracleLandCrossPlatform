using DTOCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DALorders
    {
        public int AddOrders(int userid, long total)
        {
            try
            {
                using (var dbContext = new TsmgContext())
                {
                    var orders = new Order
                    {
                        Userid = userid,
                        Total = total
                    };

                    dbContext.Orders.Add(orders);
                    dbContext.SaveChanges();
                    return orders.Orderid;
                }
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
                return 0;
            }
        }

        public async Task<List<Order>> GetAllOrdersByUser(int userid)
        {
            try
            {
                using (var dbContext = new TsmgContext())
                {
                    return await dbContext.Orders.Where(order => order.Userid == userid ).ToListAsync();
                }
                
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
                return null;
            }
        }
    }
}
