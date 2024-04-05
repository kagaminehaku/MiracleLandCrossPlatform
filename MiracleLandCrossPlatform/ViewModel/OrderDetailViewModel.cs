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
        public ObservableCollection<Order> OrderDetail { get; set; }
    }
}
