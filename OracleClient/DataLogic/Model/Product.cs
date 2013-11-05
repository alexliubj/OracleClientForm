using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLogic.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Instruction { get; set; }
        public float UnitPrice { get; set; }
        public string UnitType { get; set; }
    }
}
