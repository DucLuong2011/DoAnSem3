using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnSem3.Models
{
    public class Payment
    {
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string NameCustomer { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string svName { get; set; }
        public string nspName { get; set; }
    }
}
