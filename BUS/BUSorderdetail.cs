using DAL;
using DTOCore;

namespace BUS
{
    public class BUSorderdetail
    {
        public bool AddNewOrderDetail(int orderid, int pid, int quantity)
        {
            var dalorderdetail = new DALorderdetail();
            bool addok = dalorderdetail.AddOrderDetail(orderid, pid, quantity);
            return addok;
        }

        public async Task<List<OrderDetail>> GetAllOrderDetailByOrderId(int orderid)
        {
            var dalorderdetail = new DALorderdetail();
            return await dalorderdetail.GetAllOrderDetailByOrderId(orderid);
        }
    }
}
