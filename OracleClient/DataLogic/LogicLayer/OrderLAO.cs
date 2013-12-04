using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLogic.DataAccessLayer;
using DataLogic.Model;
namespace DataLogic.LogicLayer
{
    public class OrderLAO
    {
        private static OrderDAO dao = new OrderDAO();

        /// <summary>
        /// viii. Enter a new orders, 
        /// </summary>
        /// <param name="order"></param>
        public static void CreateNewOrder(Order order, List<OrderLines> line)
        {
            dao.AddOrder(order,line);
        }

        public static List<Reports> GetAllOrderWithInfo(int orderId,bool outstanding)
        {
           return dao.GetAllOrderWithInfo(orderId, outstanding);
        }

        public static List<Order> GetAllOrders()
        {
            return dao.GetAllOrder();
        }
        /// <summary>
        /// ix. Display orders, with all the appropriate extended totals, total before tax, GST, PST, grand totals, etc., 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static Order GetOrderById(int orderId)
        {
            return dao.GetOrderById(orderId);
        }
        /// <summary>
        /// x. A display of all outstanding orders for a particular client, to include client number, name, contact, 
        ///telephone number and order number, order date, and order total amount (grand total), 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public static List<Order> GetOrderByCustomer(int customerId)
        {
            return dao.GetOrderCustomerId(customerId);
        }
        /// <summary>
        /// xii. A display identifying the top 10 customers based on the total dollar value of all outstanding orders for 
        /// each customer, and 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static List<Reports> GetTopCustomers(int num)
        {
            return dao.GetTopCustomer(num);
        }

         /// <summary>
        /// XI. A display of all orders outstanding by groupings of less than 30 days old, 
        /// 31 to 60 days old, 61 to 90 days 
        ///old, and 91 plus days old, 
        /// </summary>
        /// <param name="daysForm"></param>
        /// <param name="daysTo"></param>
        /// <returns></returns>
        public static List<Reports> GetOrderByDate(int daysType)
        {
            return dao.GetOrderByDate(daysType);
        }

        public static int getOrderNextValue()
        {
            return dao.getOrderNextValue();
        }
        /// <summary>
        /// get aging report;
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static List<Reports> GetOutStandingReport(int status)
        {
            return dao.GetOutStandingReport(status);
        }
        /// <summary>
        /// get order lines by orderid 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static List<OrderLines> GetLinesByOrderId(int orderId)
        {
            return dao.GetLinesByOrderId(orderId);
        }

        /// <summary>
        /// update order by order and order lines
        /// </summary>
        /// <param name="ord"></param>
        /// <param name="lines"></param>
        public static void UpdateOrder(Order ord, List<OrderLines> lines)
        {
            dao.UpdateOrder(ord, lines);
        }

        /// <summary>
        /// update order status
        /// </summary>
        /// <param name="status"></param>
        /// <param name="orderId"></param>
        public static void UpdateOrderStatus(int status, int orderId)
        {
            dao.UpdateOrderStatus(status, orderId);
        }
    }
}
