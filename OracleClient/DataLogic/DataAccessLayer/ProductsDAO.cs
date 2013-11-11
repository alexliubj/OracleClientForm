using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLogic.Model;
using System.Data.OracleClient;
namespace DataLogic.DataAccessLayer
{
    public class ProductsDAO
    {
        private DataConnection dataConnection = new DataConnection();
        /// <summary>
        /// get all product
        /// </summary>
        /// <returns></returns>
        public List<Product> getProductslist()
        {
            List<Product> productList =new List<Product>();
            try
            {
                OracleCommand commn = dataConnection.ConnectToDatabase();
                commn.CommandText = "select * from product";
                OracleDataReader odr = commn.ExecuteReader();
                while (odr.Read())
                {
                    Product aProduct = new Product();

                    aProduct.ProductId = odr.GetInt32(0);
                    aProduct.Instruction = odr.GetString(1);
                    aProduct.UnitPrice = odr.GetFloat(2);
                    aProduct.UnitType = odr.GetString(3);
                    aProduct.ProductName = odr.GetString(4);

                    productList.Add(aProduct);
                }
                dataConnection.CloseDatabase();
            }
            catch (Exception e)
            { }
            finally { dataConnection.CloseDatabase(); }

            return productList;
        }

        /// <summary>
        /// get product by product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public Product getProductById(int productId)
        {
            Product aProduct = new Product();
            try
            {
                OracleCommand commn = dataConnection.ConnectToDatabase();
                commn.CommandText = "select * from product where prouctid =" + productId;
                OracleDataReader odr = commn.ExecuteReader();
                while (odr.Read())
                {
                    aProduct.ProductId = odr.GetInt32(0);
                    aProduct.Instruction = odr.GetString(1);
                    aProduct.UnitPrice = odr.GetFloat(2);
                    aProduct.UnitType = odr.GetString(3);
                    aProduct.ProductName = odr.GetString(4);
                }
                dataConnection.CloseDatabase();
            }
            catch (Exception e)
            { }
            finally { dataConnection.CloseDatabase(); }

            return aProduct;
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
