using System.Collections.Generic;

namespace Models
{


    public class Order
    {
        public int Id {get; set;}

        public List<LineItem> LineItems {get; set;}
    }
}