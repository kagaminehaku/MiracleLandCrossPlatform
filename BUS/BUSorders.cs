using DAL;

namespace BUS
{
    public class BUSorders
    {
        public string AddNewOrders(int userid, long total)
        {
            var dalorders = new DALorders();
            string oid = dalorders.AddOrders(userid, total);
            return oid;
        }
    }
}
