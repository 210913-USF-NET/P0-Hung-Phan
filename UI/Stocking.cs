using System;
using Models;
using StoreBL;
using System.Collections.Generic;
using StoreDL;
using StoreDL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.IO;

namespace UI
{
    public class Stocking : IMenu
    {
        private IProduct _product;

        public Stocking(IProduct product)
        {
            _product = product;
        }
    
        public void Start()
        {
            bool exit = false;

            List<CProduct> restock = _product.ListProducts();

            foreach(var y in restock)
            {
                Console.WriteLine($"The current Stock for {y.ProductName}, (ID: {y.ProductId}) is QTY: {y.Stock}");
            }
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Update stock inventory.");
                Console.WriteLine("2.Exit.");                

            do
            {
                switch(Console.ReadLine())
                {
                    case "1":
                        changeStock();
                        // TODO: Call DB to update the product 
                        

                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Product was not found.");
                        break;
                }
            } while (!exit);
        }

        private void changeStock()
        {
            List<CProduct> restock = _product.ListProducts();
            Console.WriteLine("");
            Console.Write("Please entered the Product ID:");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Please entered the amount of the new amount of stock :");
            int amount = int.Parse(Console.ReadLine());
            Models.CProduct stockCount = new Models.CProduct();

            foreach(var p in restock){
                if(id == p.ProductId)
                {
                    stockCount = p;
                    stockCount.Stock = amount;
                }
            }

            Console.WriteLine(stockCount.Stock);
            _product.changeStock(stockCount);
            Console.WriteLine($"\nNew stock count for {restock[id-1].ProductName} is {restock[id-1].Stock}.");
        }
    }
}