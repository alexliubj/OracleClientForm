using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLogic.Model
{
    public class OrderLines
    {
        public int OrderLineId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public float UnitPrice { get; set; }
        public int Quantity { get; set; }
        public Product ProductInfo { get; set; }
    }
}
