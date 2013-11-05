using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLogic.Model;
using System.Data.OracleClient;
namespace DataLogic.DataAccessLayer
{
    public class CustomerDAO
    {
        private DataConnection dataConnection = new DataConnection();
        /// <summary>
        /// get all custoemers
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetAllCustomers()
        {
            List<Customer> retCustomer = new List<Customer>();
            return retCustomer;
        }
        /// <summary>
        /// get customer by id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Customer GetCustomerById(int customerId)
        {
            Customer retCustomer = new Customer();

            try
            {
                OracleCommand commn = dataConnection.ConnectToDatabase();
                commn.CommandText = "select ORDERLINEID from orderline where ORDERLINEID = " + customerId;
                commn.CommandText = "select * from orderline";
                OracleDataReader odr = commn.ExecuteReader();
                while (odr.Read())
                {
                    retCustomer.CustomerId = odr.GetInt32(0);
                }
                dataConnection.CloseDatabase();
            }
            catch(Exception e)
            { }
            finally { dataConnection.CloseDatabase(); }
            return retCustomer;
        }
        /// <summary>
        /// add new customer by customer object
        /// </summary>
        /// <param name="cust"></param>
        public void AddNewCustomer(Customer cust)
        { 
        }
        /// <summary>
        /// remvoe customer by customer id
        /// </summary>
        /// <param name="customerId"></param>
        public void RemoveCustomerById(int customerId)
        { 
        }
        /// <summary>
        /// update customer by customer info
        /// </summary>
        /// <param name="cust"></param>
        public void UpdateCustomer(Customer cust)
        { 
        }
    }
}
