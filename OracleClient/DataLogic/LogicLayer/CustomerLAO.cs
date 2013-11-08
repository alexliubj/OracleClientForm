using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLogic.DataAccessLayer;
using DataLogic.Model;


namespace DataLogic.LogicLayer
{
    public class CustomerLAO
    {
        private static CustomerDAO dal = new CustomerDAO();

        /// <summary>
        /// i.Enter new customers, 
        /// </summary>
        /// <param name="customer"></param>
        public static void addNewCustomer(Customer customer)
        {
            dal.AddNewCustomer(customer);
        }
        /// <summary>
        /// ii. Display and modify all data for a customer, 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public static Customer getCustoemerById(int customerId)
        {
            return dal.GetCustomerById(customerId);
        }
        /// <summary>
        /// iii. Display all customers -name, complete address, telephone, contact, 
        /// </summary>
        /// <returns></returns>
        public static List<Customer> GetAllCustomers()
        {
            return dal.GetAllCustomers();
        }
        /// <summary>
        ///  /// ii. Display and modify all data for a customer, 
        /// </summary>
        /// <param name="cust"></param>
        public static void UpdateCustomer(Customer cust)
        {
            dal.UpdateCustomer(cust);
        }
    }
}
