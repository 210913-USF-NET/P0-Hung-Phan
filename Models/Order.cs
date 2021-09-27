using System.Collections.Generic;
using System;

namespace Models
{


    public class Order
    {
        public Order()
        {

        }

        public Order(string o_ID, int id, decimal cost, int qty, string location , decimal total, int customerID) 
        {
            this.OrderID = o_ID;
            this.ProductID = id;
            this.QTY = qty;
            this.Cost = cost;
            this.Location = location;
            this.Total = total;
            this.customerID = customerID;
        }

        public string OrderID {get; set;}
        public int ProductID {get; set;}
        public int QTY {get; set;}
        public decimal Cost {get; set;}
        public string Location {get; set;}
        public decimal Total {get; set;}
        public int customerID {get; set;} 


        public override string ToString()
        {
        return $"ProductID: {this.ProductID}, QTY: {this.QTY}, Cost of Product: {this.Cost}, Total: {this.Total}";
        }
    }
}