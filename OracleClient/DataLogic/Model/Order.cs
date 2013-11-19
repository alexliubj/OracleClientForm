using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLogic.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public int Status { get; set; }
        public float Discount { get; set; }
        public int customerId { get; set; }
        public int EmployeeId { get; set; }
        public float OrderAmount { get; set; }
        public List<OrderLines> OrderLine { get; set; }
    }
}
