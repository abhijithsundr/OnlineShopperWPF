using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopper.Domain.Models
{
    public class Product : Entity
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Category { get; set; }
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
        public double VoucherPrice { get; set; }
        public int Inventory { get; set; }
    }
}