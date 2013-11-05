using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLogic.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public float DiscountRate { get; set; }
        public DateTime RegisterDate { get; set; }
        public string CustLastName { get; set; }
        public string CustFirstName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Phone { get; set; }
        public int Fax { get; set; }
        public string Email { get; set; }
        public char MutiAddress { get; set; }
        public ShippingInfo ShipInfo { get; set; }
    }
}
