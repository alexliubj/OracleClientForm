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
        private ProductsDAO prodDao = new ProductsDAO();
        /// <summary>
        /// iv. Enter a new product, 
        /// </summary>
        /// <param name="prod"></param>
        public void AddNewProduct(Product prod)
        {
            prodDao.InsertProduct(prod);
        }
        /// <summary>
        /// v. Display all data for a product, 
        /// </summary>
        /// <param name="prodId"></param>
        /// <returns></returns>
        public Product getProductById(int prodId)
        {
            return prodDao.getProductById(prodId);
        }
        /// <summary>
        /// v.  modify all data for a product, 
        /// </summary>
        /// <param name="prod"></param>
        public void UpdateProduct(Product prod)
        {
            prodDao.UpdateProduct(prod);
        }
        /// <summary>
        /// vi. Display a complete listing of product number, description, and unit price for all products, 
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts()
        {
            return prodDao.getProductslist();
        }
        /// <summary>
        /// vii. A form permitting a mass price increase of x% for all products,
        /// </summary>
        /// <param name="rate"></param>
        public void UpdateAllPrice(float rate)
        {
            prodDao.UpdateAllPriceByRate(rate);
        }
    }
}
