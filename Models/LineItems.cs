using System;
using System.Collections.Generic;

namespace Models
{
    public class LineItems
    {
        public LineItems(){
        }
        
        //Constructor overloading
        public LineItems(int oid, int pid, int qty, int cid){
            this.OrderID = oid;
            this.ProductID = pid;
            this.ProductQty = qty;
            this.CustomerId = cid;
        }
        public LineItems(int pid, int qty, decimal price, decimal total, string loc)
        {
            this.ProductID = pid;
            this.ProductQty = qty;
            this.PriceOfProduct = price;
            this.Total = total;
            this.StoreLocation = loc;
        }

        //Constructor overloading
        public LineItems(int oid, int pid, int qty,decimal price, string loca, decimal total, int cid){
            this.OrderID = oid;
            this.ProductID = pid;
            this.ProductQty = qty;
            this.PriceOfProduct = price;
            this.StoreLocation = loca;
            this.Total = total;
            this.CustomerId = cid;
        }

        public int ProductID {get; set;}
        public int ProductQty {get; set;}
        public int OrderID {get; set;} 
        public decimal PriceOfProduct { get; set; }
        public string StoreLocation { get; set; }
        public decimal Total { get; set; }
        public int CustomerId {get; set;} 

        public override string ToString()
        {
            return $"{this.ProductID}  Location: {this.StoreLocation}  QTY: {this.ProductQty}  Total: {this.Total}";
        }
    }
}