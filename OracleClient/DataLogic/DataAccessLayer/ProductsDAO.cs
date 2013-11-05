using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLogic.Model;
namespace DataLogic.DataAccessLayer
{
    public class ProductsDAO
    {
        /// <summary>
        /// get all product
        /// </summary>
        /// <returns></returns>
        public List<Product> getProductslist()
        {
            List<Product> productList =new List<Product>();

            return productList;
        }

        /// <summary>
        /// get product by product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Product getProductById(int productId)
        {
            return new Product();
        }

        /// <summary>
        /// insert one product by product object
        /// </summary>
        /// <param name="prod"></param>
        public void InsertProduct(Product prod)
        { 
        }

        /// <summary>
        /// update product information by product object
        /// </summary>
        /// <param name="prod"></param>
        public void UpdateProduct(Product prod)
        {
 
        }
        /// <summary>
        /// A form permitting a mass price increase of x% for all products, 
        /// </summary>
        /// <param name="rate"></param>
        public void UpdateAllPriceByRate(float rate)
        { 
        }

        /// <summary>
        /// remove product by product id
        /// </summary>
        /// <param name="productId"></param>
        public void RomoveProductById(int productId)
        { 
        }
    }
}
