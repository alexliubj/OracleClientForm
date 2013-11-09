﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLogic.Model;
using System.Data.OracleClient;
namespace DataLogic.DataAccessLayer
{
    public class OrderDAO
    {

        private DataConnection dataConnection = new DataConnection();
        /// <summary>
        /// get all orders
        /// </summary>
        /// <returns></returns>
        public List<Order> GetAllOrder()
        {
            List<Order> retOrder = new List<Order>();

            try
            {
                OracleCommand commn = dataConnection.ConnectToDatabase();
                commn.CommandText = "select orderid, orderdate,shipdate,status,discount,employeeid,customerid from orders";
                OracleDataReader odr = commn.ExecuteReader();
                while (odr.Read())
                {
                    Order aOrder = new Order();
                    aOrder.OrderId = odr.GetInt32(0);
                    aOrder.OrderDate = odr.GetDateTime(1);
                    aOrder.ShipDate = odr.GetDateTime(2);
                    aOrder.Status = odr.GetInt32(3);
                    aOrder.Discount = odr.GetInt32(4);
                    aOrder.EmployeeId = odr.GetInt32(5);
                    aOrder.customerId = odr.GetInt32(6);

                    //if (string.Compare(aCustomer.MutiAddress, "N") == 0)
                    //{
                    //    ShippingInfo shipinfo = new ShippingInfo();
                    //    shipinfo.CustosmerId = aCustomer.CustomerId;

                    //    shipinfo.ShippingFirstName = odr.GetString(13);
                    //    shipinfo.ShippingStreet = odr.GetString(14);
                    //    shipinfo.ShippingState = odr.GetString(15);
                    //    shipinfo.ShippingCity = odr.GetString(16);
                    //    shipinfo.ShippingPhone = odr.GetInt32(17);
                    //    shipinfo.ShippingLastName = odr.GetString(18);
                    //    shipinfo.ShipppingPost = odr.GetString(19);
                    //    aCustomer.ShipInfo = shipinfo;
                    // }
                    retOrder.Add(aOrder);
                }
                dataConnection.CloseDatabase();
            }
            catch (Exception e)
            { }
            finally { dataConnection.CloseDatabase(); }

            return retOrder;
        }

        /// <summary>
        /// Get orderlines by order iD
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<OrderLines> GetLinesByOrderId(int orderId)
        {
            List<OrderLines> aLine = new List<OrderLines>();
            try
            {
                OracleCommand commn = dataConnection.ConnectToDatabase();
                commn.CommandText = "select o.orderlineid, p.productId, p.productname, o.quantity from product p inner join orderline o " +
                    "on p.productid = o.productid where o.orderid=" + orderId;
                OracleDataReader odr = commn.ExecuteReader();
                while (odr.Read())
                {
                    OrderLines odrLine = new OrderLines();
                    odrLine.OrderLineId = odr.GetInt32(0);
                    odrLine.OrderId = orderId;
                    odrLine.ProductId = odr.GetInt32(1);
                    Product aProduct = new Product();
                    aProduct.ProductId = odr.GetInt32(1);
                    aProduct.ProductName = odr.GetString(2);
                    odrLine.Quantity = odr.GetInt32(3);
                    odrLine.ProductInfo = aProduct;
                    aLine.Add(odrLine);
                }
                dataConnection.CloseDatabase();
            }
            catch (Exception e)
            { }
            finally { dataConnection.CloseDatabase(); }
            return aLine;
            
        }
        /// <summary>
        /// get order by order id
        /// </summary>
        /// <returns></returns>
        public Order GetOrderById()
        { 
            return new Order();
        }
        /// <summary>
        /// A display of all orders outstanding by groupings of less than 30 days old, 
        /// 31 to 60 days old, 61 to 90 days 
        ///old, and 91 plus days old, 
        /// </summary>
        /// <param name="daysForm"></param>
        /// <param name="daysTo"></param>
        /// <returns></returns>
        public List<Order> GetOrderByDate(int daysForm, int daysTo)
        {
            List<Order> retOrder = new List<Order>();
            return retOrder;
        }

        /// <summary>
        /// A display of all outstanding orders for a particular client, to include client number, name, contact, 
        /// telephone number and order number, order date, and order total amount (grand total), 
        /// </summary>
        /// <param name="cusId"></param>
        /// <returns></returns>
        public List<Order> GetOrderCustomerId(int cusId)
        {
            List<Order> retOrder = new List<Order>();
            return retOrder;
        }
        /// <summary>
        /// add order by order object
        /// </summary>
        /// <param name="ord"></param>
        public void AddOrder(Order ord)
        { }
        /// <summary>
        /// remove order by order id
        /// </summary>
        /// <param name="orderId"></param>
        public void RemoverOrder(int orderId)
        { }
        /// <summary>
        /// update order by order object
        /// </summary>
        /// <param name="ord"></param>
        public void UpdateOrder(Order ord)
        { }

        /// <summary>
        /// A display identifying the top *
        /// customers based on the total dollar value of all outstanding orders for 
        /// each customer, and 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public List<Customer> GetTopCustomer(int num)
        {
            List<Customer> retCustomer = new List<Customer>();
            return retCustomer;
        }
    }
}
