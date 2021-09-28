using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class OrderDetail
    {
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductQty { get; set; }
        public decimal PriceOfProduct { get; set; }
        public string StoreLocation { get; set; }
        public decimal Total { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
