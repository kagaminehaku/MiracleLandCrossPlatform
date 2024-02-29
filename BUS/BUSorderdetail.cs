using DAL;

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
    }
}
