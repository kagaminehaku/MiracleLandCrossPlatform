using DTOCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DALproduct
    {
        public List<Product> GetAllProduct()
        {
            using (var dbContext = new TsmgContext())
            {
                return dbContext.Products.AsNoTracking().ToList();
            }
        }

        public Product GetProductByID(int pid)
        {
            using (var dbContext = new TsmgContext())
            {
                return dbContext.Products.FirstOrDefault(u => u.Pid == pid);
            }
        }

        public Product GetProductByName(string pname)
        {
            using (var dbContext = new TsmgContext())
            {
                return dbContext.Products.FirstOrDefault(u => u.Pname == pname);
            }
        }

        public string AddNewProduct(string pname, int pprice, int pquantity, string pinfo, string pimg)
        {
            try
            {
                using (var dbContext = new TsmgContext())
                {
                    var existingProduct = GetProductByName(pname);
                    if (existingProduct != null)
                    {
                        return "Product name is Duplicate";
                    }

                    var product = new Product
                    {
                        Pname = pname,
                        Pprice = pprice,
                        Pquantity = pquantity,
                        Pinfo = pinfo,
                        Pimg = pimg
                    };

                    dbContext.Products.Add(product);
                    dbContext.SaveChanges();
                    return product.Pname;
                }
            }
            catch (Exception ex)
            {
                return "An error occurred: " + ex.Message;
            }
        }

        public bool UpdateProduct(int id, string newpname, int newpprice, int newquantity, string newpinfo, string pimg)
        {
            try
            {
                using (var dbContext = new TsmgContext())
                {
                    var product = dbContext.Products.Find(id);
                    if (product == null) return false;
                    product.Pname = newpname;
                    product.Pprice = newpprice;
                    product.Pquantity = newquantity;
                    product.Pinfo = newpinfo;
                    product.Pimg = pimg;
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                return false;
            }
        }

        public bool UpdateProductQuantity(int id, int newquantity)
        {
            try
            {
                using (var dbContext = new TsmgContext())
                {
                    var product = dbContext.Products.Find(id);
                    if (product == null) return false;
                    product.Pquantity = newquantity;
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                return false;
            }
        }

        public bool RemoveProduct(int id)
        {
            try
            {
                using (var dbContext = new TsmgContext())
                {
                    var product = dbContext.Products.Find(id);
                    if (product == null) return false;
                    dbContext.Products.Remove(product);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
                return false;
            }
        }

    }
}
