using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DTOCore;
using BUS;

namespace MiracleLandCrossPlatform.ViewModel
{
    public class ProductViewModel
    {
        public ObservableCollection<Product> Products { get; set; }

        public async Task LoadProductsAsync()
        {
            var busproduct = new BUSproduct();
            var products = await busproduct.GetAllProductAsync();
            Products = new ObservableCollection<Product>(products);
        }

    }
}
