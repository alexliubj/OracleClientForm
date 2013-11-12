﻿using System;
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
            try
            {
                OracleCommand commn = dataConnection.ConnectToDatabase("insert into product values (:productid,:INSTRUCTION,:UNITPRICE,:UNITTYPE,:PRODUCTNAME)");
                commn.Parameters.Add(new OracleParameter("PRODUCTID", prod.ProductId));
                commn.Parameters.Add(new OracleParameter("INSTRUCTION", prod.Instruction));
                commn.Parameters.Add(new OracleParameter("UNITPRICE", prod.UnitPrice));
                commn.Parameters.Add(new OracleParameter("UNITTYPE", prod.UnitType));
                commn.Parameters.Add(new OracleParameter("PRODUCTNAME", prod.ProductName));

                int result = commn.ExecuteNonQuery();

                dataConnection.CloseDatabase();
            }
            catch (Exception e)
            { }
            finally
            {
                dataConnection.CloseDatabase();
            }
        }

        /// <summary>
        /// update product information by product object
        /// </summary>
        /// <param name="prod"></param>
        public void UpdateProduct(Product prod)
        {
            try
            {
                OracleCommand commn = dataConnection.ConnectToDatabase("update product set INSTRUCTION=:INSTRUCTION,UNITPRICE=:UNITPRICE,UNITTYPE=:UNITTYPE,PRODUCTNAME=:PRODUCTNAME where PRODUCTID=:PRODUCTID");
                commn.Parameters.Add(new OracleParameter("PRODUCTID", prod.ProductId));
                commn.Parameters.Add(new OracleParameter("INSTRUCTION", prod.Instruction));
                commn.Parameters.Add(new OracleParameter("UNITPRICE", prod.UnitPrice));
                commn.Parameters.Add(new OracleParameter("UNITTYPE", prod.UnitType));
                commn.Parameters.Add(new OracleParameter("PRODUCTNAME", prod.ProductName));

                int result = commn.ExecuteNonQuery();

                dataConnection.CloseDatabase();
            }
            catch (Exception e)
            { }
            finally
            {
                dataConnection.CloseDatabase();
            }
        }
        /// <summary>
        /// A form permitting a mass price increase of x% for all products, 
        /// </summary>
        /// <param name="rate"></param>
        public void UpdateAllPriceByRate(float rate)
        {
            try
            {
                OracleCommand commn = dataConnection.ConnectToDatabase();
                commn.CommandText = "update product set unitprice = unitprice*" + rate;
                int result = commn.ExecuteNonQuery();
                dataConnection.CloseDatabase();
            }
            catch (Exception e)
            { }
            finally { dataConnection.CloseDatabase(); }
        }

        /// <summary>
        /// remove product by product id
        /// </summary>
        /// <param name="productId"></param>
        public void RomoveProductById(int productId)
        {
            try
            {
                OracleCommand commn = dataConnection.ConnectToDatabase();
                commn.CommandText = "delete from product where productid = " + productId;
                int result = commn.ExecuteNonQuery();
                dataConnection.CloseDatabase();
            }
            catch (Exception e)
            { }
            finally { dataConnection.CloseDatabase(); }
        }
    }
}
