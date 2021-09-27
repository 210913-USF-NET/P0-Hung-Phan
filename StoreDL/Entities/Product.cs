using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string InventoryLocation { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}