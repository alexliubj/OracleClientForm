using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLogic.DataAccessLayer;
using DataLogic.Model;
namespace DataLogic.LogicLayer
{
    public class ProductsLAO
    {
        private static ProductsDAO prodDao = new ProductsDAO();
        /// <summary>
        /// iv. Enter a new product, 
        /// </summary>
        /// <param name="prod"></param>
        public static void AddNewProduct(Product prod)
        {
            prodDao.InsertProduct(prod);
        }
        
        /// <summary>
        /// v. Display all data for a product, 
        /// </summary>
        /// <param name="prodId"></param>
        /// <returns></returns>
        public static Product getProductById(int prodId)
        {
            return prodDao.getProductById(prodId);
        }

        public static Product getProductByName(string name)
        {
            return prodDao.getProductByName(name);
        }

        /// <summary>
        /// v.  modify all data for a product, 
        /// </summary>
        /// <param name="prod"></param>
        public static void UpdateProduct(Product prod)
        {
            prodDao.UpdateProduct(prod);
        }
        /// <summary>
        /// vi. Display a complete listing of product number, description, and unit price for all products, 
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetAllProducts()
        {
            return prodDao.getProductslist();
        }
        /// <summary>
        /// vii. A form permitting a mass price increase of x% for all products,
        /// </summary>
        /// <param name="rate"></param>
        public static void UpdateAllPrice(float rate)
        {
            prodDao.UpdateAllPriceByRate(rate);
        }

        public static void RemoveProductById(int productId)
        {
            prodDao.RomoveProductById(productId);
        }
    }
}
