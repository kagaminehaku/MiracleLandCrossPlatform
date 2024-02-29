using DTOCore;
using System;

namespace DAL
{
    public class DALorders
    {
        public string AddOrders(int userid, long total)
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
                    return orders.Orderid.ToString();
                }
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.GetType().Name} - {ex.Message}\nStack Trace: {ex.StackTrace}";
            }
        }
    }
}
