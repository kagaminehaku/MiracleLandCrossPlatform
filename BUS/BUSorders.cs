using DAL;

namespace BUS
{
    public class BUSorders
    {
        public int AddNewOrders(int userid, long total)
        {
            var dalorders = new DALorders();
            int oid = dalorders.AddOrders(userid, total);
            return oid;
        }
    }
}
