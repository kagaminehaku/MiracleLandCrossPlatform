using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DTOCore;
using BUS;
using System.Windows.Input;

namespace MiracleLandCrossPlatform.ViewModel
{
    public class OrdersView
    {
        public ObservableCollection<Order> Order { get; set; }

        public async Task LoadOrderAsync(int uid)
        {
            var orderlist = new List<Order>();
            int orderlistid = 1;
            var busorder = new BUSorders();
            var orderlistpreset = await busorder.GetAllOrdersByUser(uid);
            foreach (Order orders in orderlistpreset)
            {
                orders.Orderid = orderlistid;
                orderlist.Add(orders);
                orderlistid++; 
            }
            Order = new ObservableCollection<Order>(orderlist);
        }
    }
}
