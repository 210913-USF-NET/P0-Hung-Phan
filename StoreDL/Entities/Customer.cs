using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Username { get; set; }
        public string CPassword { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
