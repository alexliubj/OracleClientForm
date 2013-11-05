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
        private OrderDAO dao = new OrderDAO();

        /// <summary>
        /// viii. Enter a new orders, 
        /// </summary>
        /// <param name="order"></param>
        public void CreateNewOrder(Order order)
        {
            dao.AddOrder(order);
        }

        public List<Order> GetAllOrders()
        {
            return dao.GetAllOrder();
        }
        /// <summary>
        /// ix. Display orders, with all the appropriate extended totals, total before tax, GST, PST, grand totals, etc., 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Order GetOrderById(int orderId)
        {
            return dao.GetOrderById();
        }
        /// <summary>
        /// x. A display of all outstanding orders for a particular client, to include client number, name, contact, 
        ///telephone number and order number, order date, and order total amount (grand total), 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public List<Order> GetOrderByCustomer(int customerId)
        {
            return dao.GetOrderCustomerId(customerId);
        }
        /// <summary>
        /// xii. A display identifying the top 10 customers based on the total dollar value of all outstanding orders for 
        /// each customer, and 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public List<Customer> GetTopCustomers(int num)
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
        public List<Order> GetOrderByDate(int daysForm, int daysTo)
        {
            return dao.GetOrderByDate(daysForm, daysTo);
        }
    }
}
