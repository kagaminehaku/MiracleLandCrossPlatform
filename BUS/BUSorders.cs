using DAL;
using DTOCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        public async Task<List<Order>> GetAllOrdersByUser (int userid)
        {
            var dalorders = new DALorders();
            return await dalorders.GetAllOrdersByUser(userid);
        }

    }
}
