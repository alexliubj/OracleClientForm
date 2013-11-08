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
            try
            {
                OracleCommand commn = dataConnection.ConnectToDatabase();
                commn.CommandText = "select customerid, discountrate, registerdate, custfname, custlname, state, street, city,phone, fax, email, multiaddress from customers";
                OracleDataReader odr = commn.ExecuteReader();
                while (odr.Read())
                {
                    Customer aCustomer = new Customer();
                    aCustomer.CustomerId = odr.GetInt32(0);
                    aCustomer.DiscountRate = odr.GetFloat(1);
                    aCustomer.RegisterDate = odr.GetDateTime(2);
                    aCustomer.CustFirstName = odr.GetString(3);
                    aCustomer.CustLastName = odr.GetString(4);
                    aCustomer.State = odr.GetString(5);
                    aCustomer.Street = odr.GetString(6);
                    aCustomer.City = odr.GetString(7);
                    aCustomer.Phone = odr.GetInt32(8);
                    aCustomer.Fax = odr.GetInt32(9);
                    aCustomer.Email = odr.GetString(10);
                   // aCustomer.MutiAddress = (char)odr.GetInt32(11);
                    retCustomer.Add(aCustomer);

                }
                dataConnection.CloseDatabase();
            }
            catch (Exception e)
            { }
            finally { dataConnection.CloseDatabase(); }
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
                commn.CommandText = "";
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
            try
            {
                OracleCommand commn = dataConnection.ConnectToDatabase("insert into customers values (:customerid,:discountrate,:registerdate,:custfname,:custlname,:street,:city,:state,:phone,:fax,:email,'Y')");
                commn.Parameters.Add(new OracleParameter("customerid", cust.CustomerId));
                commn.Parameters.Add(new OracleParameter("discountrate", cust.DiscountRate));
                commn.Parameters.Add(new OracleParameter("registerdate", cust.RegisterDate));
                commn.Parameters.Add(new OracleParameter("custfname", cust.CustFirstName));
                commn.Parameters.Add(new OracleParameter("custlname", cust.CustLastName));
                commn.Parameters.Add(new OracleParameter("state", cust.State));
                commn.Parameters.Add(new OracleParameter("street", cust.Street));
                commn.Parameters.Add(new OracleParameter("city", cust.City));
                commn.Parameters.Add(new OracleParameter("phone", cust.Phone));
                commn.Parameters.Add(new OracleParameter("fax", cust.Fax));
                commn.Parameters.Add(new OracleParameter("email", "test@test.com"));
                //commn.Parameters.Add(new OracleParameter("multiaddress", cust.MutiAddress));
                string sss = commn.ToString();
                int result = commn.ExecuteNonQuery();
                dataConnection.CloseDatabase();
            }
            catch (Exception e)
            { }
            finally { dataConnection.CloseDatabase(); }
        }
        /// <summary>
        /// remvoe customer by customer id
        /// </summary>
        /// <param name="customerId"></param>
        public void RemoveCustomerById(int customerId)
        {
            try
            {
                OracleCommand commn = dataConnection.ConnectToDatabase();
                commn.CommandText = "delete from customers where cusotmerid =" + customerId;
                int result = commn.ExecuteNonQuery();
                dataConnection.CloseDatabase();
            }
            catch (Exception e)
            { }
            finally { dataConnection.CloseDatabase(); }
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
