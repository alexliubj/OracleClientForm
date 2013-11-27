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
                commn.CommandText = "select cus.customerid, discountrate, registerdate, custfname, custlname, state, street, city,phone, fax, email, multiaddress,postcode," +
                            "s.shippingfname,s.shippingstreet, s.shippingstate,s.shippingcity,s.shippingphone,s.SHIPPINGLNAME,s.shippingpost,CUSTNAME " +
                            "from customers cus left join shippinginfo s " +
                            "on cus.customerid = s.customerid";
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
                    aCustomer.Phone = odr.GetString(8);
                    aCustomer.Fax = odr.GetString(9);
                    aCustomer.Email = odr.GetString(10);
                    aCustomer.MutiAddress = odr.GetString(11);
                    aCustomer.PostCode = odr.GetString(12) == null ? "" : odr.GetString(12);
                    aCustomer.CUSTNAME = odr.GetString(20);
                    if(string.Compare(aCustomer.MutiAddress, "N") ==0)
                    {
                        ShippingInfo shipinfo = new ShippingInfo();
                        shipinfo.CustosmerId = aCustomer.CustomerId;
                        
                        shipinfo.ShippingFirstName = odr.GetString(13);
                        shipinfo.ShippingStreet = odr.GetString(14);
                        shipinfo.ShippingState = odr.GetString(15);
                        shipinfo.ShippingCity = odr.GetString(16);
                        shipinfo.ShippingPhone = odr.GetInt32(17);
                        shipinfo.ShippingLastName = odr.GetString(18);
                        shipinfo.ShipppingPost = odr.GetString(19);
                        aCustomer.ShipInfo = shipinfo;
                    }

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
            Customer aCustomer = new Customer();
            try
            {
                OracleCommand commn = dataConnection.ConnectToDatabase();
                commn.CommandText = "select cus.customerid, discountrate, registerdate, custfname, custlname, state, street, city,phone, fax, email, multiaddress,postcode," +
                            "s.shippingfname,s.shippingstreet, s.shippingstate,s.shippingcity,s.shippingphone,s.SHIPPINGLNAME,s.shippingpost,CUSTNAME " +
                            "from customers cus left join shippinginfo s " +
                            "on cus.customerid = s.customerid " +
                            "where cus.customerid =" + customerId;
                OracleDataReader odr = commn.ExecuteReader();
                while (odr.Read())
                {
                    aCustomer.CustomerId = odr.GetInt32(0);
                    aCustomer.DiscountRate = odr.GetFloat(1);
                    aCustomer.RegisterDate = odr.GetDateTime(2);
                    aCustomer.CustFirstName = odr.GetString(3);
                    aCustomer.CustLastName = odr.GetString(4);
                    aCustomer.State = odr.GetString(5);
                    aCustomer.Street = odr.GetString(6);
                    aCustomer.City = odr.GetString(7);
                    aCustomer.Phone = odr.GetString(8);
                    aCustomer.Fax = odr.GetString(9);
                    aCustomer.Email = odr.GetString(10);
                    aCustomer.MutiAddress = odr.GetString(11);
                    aCustomer.PostCode = odr.GetString(12) == null ? "" : odr.GetString(12);
                    aCustomer.CUSTNAME = odr.GetString(20);
                    if (string.Compare(aCustomer.MutiAddress, "N") == 0)
                    {
                        ShippingInfo shipinfo = new ShippingInfo();
                        shipinfo.CustosmerId = aCustomer.CustomerId;

                        shipinfo.ShippingFirstName = odr.GetString(13);
                        shipinfo.ShippingStreet = odr.GetString(14);
                        shipinfo.ShippingState = odr.GetString(15);
                        shipinfo.ShippingCity = odr.GetString(16);
                        shipinfo.ShippingPhone = odr.GetInt32(17);
                        shipinfo.ShippingLastName = odr.GetString(18);
                        shipinfo.ShipppingPost = odr.GetString(19);
                        aCustomer.ShipInfo = shipinfo;
                    }
                }
                dataConnection.CloseDatabase();
            }
            catch (Exception e)
            { }
            finally { dataConnection.CloseDatabase(); }
            return aCustomer;
        }

        public List<Customer> GetCustomerByName(string customerName)
        {
            List<Customer> retCustomer = new List<Customer>();
            try
            {
                OracleCommand commn = dataConnection.ConnectToDatabase();
                commn.CommandText = "select cus.customerid, discountrate, registerdate, custfname, custlname, state, street, city,phone, fax, email, multiaddress,postcode," +
                            "s.shippingfname,s.shippingstreet, s.shippingstate,s.shippingcity,s.shippingphone,s.SHIPPINGLNAME,s.shippingpost,CUSTNAME " +
                            "from customers cus left join shippinginfo s " +
                            "on cus.customerid = s.customerid " +
                            "where cus.custfname || ' ' || cus.custlname =" + "'" + customerName + "'";
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
                    aCustomer.Phone = odr.GetString(8);
                    aCustomer.Fax = odr.GetString(9);
                    aCustomer.Email = odr.GetString(10);
                    aCustomer.MutiAddress = odr.GetString(11);
                    aCustomer.PostCode = odr.GetString(12) == null ? "" : odr.GetString(12);
                    aCustomer.CUSTNAME = odr.GetString(20);
                    if (string.Compare(aCustomer.MutiAddress, "N") == 0)
                    {
                        ShippingInfo shipinfo = new ShippingInfo();
                        shipinfo.CustosmerId = aCustomer.CustomerId;

                        shipinfo.ShippingFirstName = odr.GetString(13);
                        shipinfo.ShippingStreet = odr.GetString(14);
                        shipinfo.ShippingState = odr.GetString(15);
                        shipinfo.ShippingCity = odr.GetString(16);
                        shipinfo.ShippingPhone = odr.GetInt32(17);
                        shipinfo.ShippingLastName = odr.GetString(18);
                        shipinfo.ShipppingPost = odr.GetString(19);
                        aCustomer.ShipInfo = shipinfo;
                    }

                    retCustomer.Add(aCustomer);

                }
                dataConnection.CloseDatabase();
            }
            catch (Exception e)
            { }
            finally { dataConnection.CloseDatabase(); }
            return retCustomer;
        }

        public int getCustomerCurrentVal()
        {
            int ret = 0;
            try
            {
                OracleCommand commn = dataConnection.ConnectToDatabase();
                commn.CommandText = "select custid_seq.nextval from dual";
                OracleDataReader odr = commn.ExecuteReader();
                while (odr.Read())
                {
                    ret = odr.GetInt32(0);
                }
                dataConnection.CloseDatabase();
            }
            catch (Exception e)
            { }
            finally { dataConnection.CloseDatabase(); }
            return ret;
        }

        /// <summary>
        /// add new customer by customer object
        /// </summary>
        /// <param name="cust"></param>
        public void AddNewCustomer(Customer cust)
        {
            try
            {
                OracleCommand commn = dataConnection.ConnectToDatabase("insert into customers values (:customerid,:discountrate,:registerdate,:custfname,:custlname,:street,:city,:state,:phone,:fax,:email,:multiaddress,:postcode,:CUSTNAME)");
                commn.Parameters.Add(new OracleParameter("customerid", cust.CustomerId));
                commn.Parameters.Add(new OracleParameter("discountrate", cust.DiscountRate));
                commn.Parameters.Add(new OracleParameter("registerdate", DateTime.Now));
                commn.Parameters.Add(new OracleParameter("custfname", cust.CustFirstName));
                commn.Parameters.Add(new OracleParameter("custlname", cust.CustLastName));
                commn.Parameters.Add(new OracleParameter("state", cust.State));
                commn.Parameters.Add(new OracleParameter("street", cust.Street));
                commn.Parameters.Add(new OracleParameter("city", cust.City));
                commn.Parameters.Add(new OracleParameter("phone", cust.Phone));
                commn.Parameters.Add(new OracleParameter("fax", cust.Fax));
                commn.Parameters.Add(new OracleParameter("email", "test@test.com"));
                commn.Parameters.Add(new OracleParameter("multiaddress", cust.MutiAddress));
                commn.Parameters.Add(new OracleParameter("postcode", cust.PostCode));
                commn.Parameters.Add(new OracleParameter("CUSTNAME", cust.CUSTNAME));
                string sss = commn.ToString();
                int result = commn.ExecuteNonQuery();

                if (string.Compare(cust.MutiAddress , "N") ==0)
                {
                    commn = dataConnection.ConnectToDatabase("insert into shippinginfo values (:SHIPPINGLNAME, :shippingfname,:shippingstreet, :shippingstate,:shippingphone,:customerid,:shippingcity,:shippingpost)");
                    commn.Parameters.Add(new OracleParameter("customerid", cust.CustomerId));
                    commn.Parameters.Add(new OracleParameter("SHIPPINGLNAME", cust.ShipInfo.ShippingLastName));
                    commn.Parameters.Add(new OracleParameter("shippingfname", cust.ShipInfo.ShippingFirstName));
                    commn.Parameters.Add(new OracleParameter("shippingstreet", cust.ShipInfo.ShippingStreet));
                    commn.Parameters.Add(new OracleParameter("shippingstate", cust.ShipInfo.ShippingState));
                    commn.Parameters.Add(new OracleParameter("shippingcity", cust.ShipInfo.ShippingCity));
                    commn.Parameters.Add(new OracleParameter("shippingpost", cust.ShipInfo.ShipppingPost));
                    commn.Parameters.Add(new OracleParameter("shippingphone", cust.ShipInfo.ShippingPhone));
                    result = commn.ExecuteNonQuery();
                }
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
            try
            {
                OracleCommand commn = dataConnection.ConnectToDatabase("update customers set discountrate=:discountrate,registerdate=:registerdate,"+
                "custfname=:custfname,custlname=:custlname,street=:street,city=:city,state=:state,phone=:phone,fax=:fax,email=:email,multiaddress=:multiaddress,postcode=:postcode CUSTNAME=:CUSTNAME where customerid=:customerid");
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
                commn.Parameters.Add(new OracleParameter("multiaddress", cust.MutiAddress));
                commn.Parameters.Add(new OracleParameter("postcode", cust.PostCode));
                commn.Parameters.Add(new OracleParameter("CUSTNAME", cust.CUSTNAME));
                string sss = commn.ToString();
                int result = commn.ExecuteNonQuery();

                if (string.Compare(cust.MutiAddress, "N") == 0)
                {
                    commn = dataConnection.ConnectToDatabase("update shippinginfo set SHIPPINGLNAME=:SHIPPINGLNAME, shippingfname=:shippingfname,shippingstreet=:shippingstreet, shippingstate=:shippingstate," +
                        "shippingphone=:shippingphone,shippingcity=:shippingcity,shippingpost=:shippingpost where customerid=:customerid");
                    commn.Parameters.Add(new OracleParameter("customerid", cust.CustomerId));
                    commn.Parameters.Add(new OracleParameter("SHIPPINGLNAME", cust.ShipInfo.ShippingLastName));
                    commn.Parameters.Add(new OracleParameter("shippingfname", cust.ShipInfo.ShippingFirstName));
                    commn.Parameters.Add(new OracleParameter("shippingstreet", cust.ShipInfo.ShippingStreet));
                    commn.Parameters.Add(new OracleParameter("shippingstate", cust.ShipInfo.ShippingState));
                    commn.Parameters.Add(new OracleParameter("shippingcity", cust.ShipInfo.ShippingCity));
                    commn.Parameters.Add(new OracleParameter("shippingpost", cust.ShipInfo.ShipppingPost));
                    commn.Parameters.Add(new OracleParameter("shippingphone", cust.ShipInfo.ShippingPhone));
                    result = commn.ExecuteNonQuery();
                }
                dataConnection.CloseDatabase();
            }
            catch (Exception e)
            { }
            finally { dataConnection.CloseDatabase(); }
        }
    }
}
