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

                Console.WriteLine("");
                Console.WriteLine("Current Inventory Quantity:");
                Console.WriteLine($"1.{restock[0].ProductName} Product ID: {restock[0].ProductId} -------------------------------- In-Store  QTY: {restock[0].Stock}");
                Console.WriteLine($"2.{restock[10].ProductName} Product ID: {restock[10].ProductId}-------------------------------- Online    QTY: {restock[11].Stock}");
                Console.WriteLine($"3.{restock[1].ProductName} --------------------------------- In-Store  QTY: {restock[1].Stock}");
                Console.WriteLine($"4.{restock[11].ProductName} --------------------------------- Online    QTY: {restock[11].Stock}");
                Console.WriteLine($"5.{restock[2].ProductName} ----------------------------- In-Store  QTY: {restock[2].Stock}");
                Console.WriteLine($"6.{restock[12].ProductName} ----------------------------- Online    QTY: {restock[12].Stock}");
                Console.WriteLine($"7.{restock[3].ProductName} ---------------------------------- In-Store  QTY: {restock[3].Stock}");
                Console.WriteLine($"8.{restock[13].ProductName} ---------------------------------- Online    QTY: {restock[13].Stock}");
                Console.WriteLine($"9.{restock[4].ProductName} ---------------------------- In-Store  QTY: {restock[4].Stock}");
                Console.WriteLine($"10.{restock[14].ProductName} --------------------------- Online    QTY: {restock[14].Stock}");
                Console.WriteLine($"11.{restock[5].ProductName} ----------------------------- In-Store  QTY: {restock[5].Stock}");
                Console.WriteLine($"12.{restock[15].ProductName} ----------------------------- Online    QTY: {restock[15].Stock}");
                Console.WriteLine($"13.{restock[6].ProductName} ------------------------------- In-Store  QTY: {restock[6].Stock}");
                Console.WriteLine($"14.{restock[16].ProductName} ------------------------------- Online    QTY: {restock[16].Stock}");
                Console.WriteLine($"15.{restock[7].ProductName} ------------------------------ In-Store  QTY: {restock[7].Stock}");
                Console.WriteLine($"16.{restock[17].ProductName} ------------------------------ Online    QTY: {restock[17].Stock}");
                Console.WriteLine($"17.{restock[8].ProductName} ------------------------------- In-Store  QTY: {restock[8].Stock}");
                Console.WriteLine($"18.{restock[18].ProductName} ------------------------------- Online    QTY: {restock[18].Stock}");
                Console.WriteLine($"19.{restock[9].ProductName} -------------------- In-Store  QTY: {restock[9].Stock}");
                Console.WriteLine($"20.{restock[19].ProductName} -------------------- Online    QTY: {restock[19].Stock}");
                Console.WriteLine($"21.{restock[20].ProductName} ---------- Online    QTY: {restock[20].Stock}");               
                Console.WriteLine($"22.{restock[21].ProductName} ------------------- Online    QTY: {restock[21].Stock}");
                Console.WriteLine($"23.{restock[22].ProductName} --------------------------- Online    QTY: {restock[22].Stock}");
                Console.WriteLine($"24.{restock[23].ProductName} ---------------------------------- Online    QTY: {restock[23].Stock}");
                Console.WriteLine($"25.{restock[24].ProductName} ----------------------------------- Online    QTY: {restock[24].Stock}");
                Console.WriteLine("");
                Console.Write("Pick a product to manage inventory stock:");

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

            if(id < 11 && id > 0){
                id -= 1;
            }else if(id < 116 && id > 100)
            {
                id -= 91;
            }else 
            {
                Console.WriteLine("\nPlease Enter Valid Product ID.\n");
                new MainMenu().Start();
            }

            Console.Write("Please entered the amount of the new amount of stock :");
            int amount = int.Parse(Console.ReadLine());

            Models.CProduct stockCount = new Models.CProduct(amount);
            _product.changeStock(stockCount, amount);
            Console.WriteLine($"\nNew stock count for {restock[id].ProductName} is {restock[id].Stock}.");
        }
    }
}