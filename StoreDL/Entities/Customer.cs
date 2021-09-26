using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            OrderHistories = new HashSet<OrderHistory>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Username { get; set; }
        public string CPassword { get; set; }

        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
    }
}
