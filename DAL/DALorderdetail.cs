using DTOCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DALorderdetail
    {
        public bool AddOrderDetail(int orderid, int pid, int quantity)
        {
            try
            {
                using (var dbContext = new TsmgContext())
                {
                    var orders_detail = new OrderDetail
                    {
                        Orderid = orderid,
                        Pid = pid,
                        Quantity = quantity
                    };

                    dbContext.OrderDetails.Add(orders_detail);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<OrderDetail>> GetAllOrderDetailByOrderId(int orderid)
        {
            try
            {
                using (var dbContext = new TsmgContext())
                {
                    return await dbContext.OrderDetails.Where(orderdetail => orderdetail.Orderid == orderid).ToListAsync();
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
