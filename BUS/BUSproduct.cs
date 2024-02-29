using DAL;
using DTOCore;
using System.Collections.Generic;
using System.IO;

namespace BUS
{
    public class BUSproduct
    {
        public List<Product> GetAllProduct()
        {
            var dalproduct = new DALproduct();
            return dalproduct.GetAllProduct();
        }

        public string AddNewProduct(string newpname, int newpprice, int newpquantity, string newpinfo, string newpimg)
        {
            var dalproduct = new DALproduct();
            string productname = dalproduct.AddNewProduct(newpname, newpprice, newpquantity, newpinfo, newpimg);
            return productname;
        }

        public bool EditProduct(int id, string newpname, int newpprice, int newpquantity, string newpinfo, string newpimg)
        {
            var dalproduct = new DALproduct();
            return dalproduct.UpdateProduct(id, newpname, newpprice, newpquantity, newpinfo, newpimg);
        }

        public bool RemoveProduct(int id, string imagepath)
        {
            File.Delete(imagepath);
            var dalproduct = new DALproduct();
            return dalproduct.RemoveProduct(id);
        }

        public void RemoveImage(string imagepath)
        {
            File.Delete(imagepath);
        }

        public Product GetProduct(int id)
        {
            var dalproduct = new DALproduct();
            return dalproduct.GetProductByID(id);
        }

        public void UpdateProductQuantity(int id, int minusquantity)
        {
            var dalproduct = new DALproduct();
            var product = GetProduct(id);
            int quantity = product.Pquantity - minusquantity;
            dalproduct.UpdateProductQuantity(id, quantity);
        }
    }
}
