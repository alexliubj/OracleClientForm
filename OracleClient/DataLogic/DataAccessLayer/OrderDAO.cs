using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLogic.Model;
namespace DataLogic.DataAccessLayer
{
    public class OrderDAO
    {
        /// <summary>
        /// get all orders
        /// </summary>
        /// <returns></returns>
        public List<Order> GetAllOrder()
        { 
            List<Order> retOrder = new List<Order>();
            return retOrder;
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
