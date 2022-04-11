using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopper.Domain.Models
{
    public class Account : Entity
    {
        public User AccountHolder { get; set; }
        public double VoucherBalance { get; set; }
        public double CashBalance { get; set; }
    }
}
