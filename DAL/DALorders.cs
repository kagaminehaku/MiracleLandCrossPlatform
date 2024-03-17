using DTOCore;
using System;

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
                return 0;
            }
        }
    }
}
