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
    public class OrderDetailView
    {
        public ObservableCollection<Product> OrderDetail { get; set; }

        public async Task LoadOrderDetailAsync(int oid)
        {
            var orderlist = new List<Product>();
            int orderdetaillistid = 1;
            var busorderdetail = new BUSorderdetail();
            var orderdtlistpreset = await busorderdetail.GetAllOrderDetailByOrderId(oid);
            foreach (OrderDetail ordersdetail in orderdtlistpreset)
            {
                var busproduct = new BUSproduct();
                var curproduct = busproduct.GetProduct(ordersdetail.Pid);
                curproduct.Pquantity=ordersdetail.Quantity;
                curproduct.Pprice = curproduct.Pprice * ordersdetail.Quantity;
                curproduct.Pid = orderdetaillistid;
                orderdetaillistid++;
                orderlist.Add(curproduct);
            }
            OrderDetail = new ObservableCollection<Product>(orderlist);
        }
    }
}
