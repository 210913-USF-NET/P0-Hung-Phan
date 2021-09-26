using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class OrderHistory
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public string InventoryLocation { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
