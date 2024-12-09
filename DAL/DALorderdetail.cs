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

        public bool DeleteOrderDetailByPid(int pid)
        {
            try
            {
                using (var dbContext = new TsmgContext())
                {
                    var orderDetails = dbContext.OrderDetails.Where(od => od.Pid == pid).ToList();

                    if (orderDetails.Count == 0)
                        return true;
                    foreach (var orderDetail in orderDetails)
                    {
                        var product = dbContext.Products.FirstOrDefault(p => p.Pid == orderDetail.Pid);
                        if (product != null)
                        {
                            var order = dbContext.Orders.FirstOrDefault(o => o.Orderid == orderDetail.Orderid);
                            if (order != null)
                            {
                                order.Total -= product.Pprice * orderDetail.Quantity;
                            }
                        }
                    }

                    dbContext.OrderDetails.RemoveRange(orderDetails);

                    dbContext.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
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
