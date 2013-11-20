using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLogic.Model
{
    public class Reports
    {
        public int orderid { get; set; }
        public DateTime orderDate { get; set; }
        public int customerId { get; set; }
        public string custFirstName { get; set; }
        public string custLastName { get; set; }
        public float amount { get; set; }
    }
}