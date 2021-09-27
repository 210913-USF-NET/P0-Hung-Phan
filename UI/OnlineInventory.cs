using System;
using Models;
using StoreBL;
using Serilog;
using System.Collections.Generic;
using System.Collections;
using StoreDL;
using StoreDL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.IO;

namespace UI
{
    public class OnlineInventory : IMenu
    {
        private IProduct _product;

        public OnlineInventory(IProduct product)
        {
            _product = product;
        }
        
        //Need to make layout for online Inventory Menu
        public void Start()
        {
            Dictionary<CProduct, int> shoppingCart = new Dictionary<CProduct, int>();
            bool exit = false;
            int fullCart = 0;

            do
            {
                Console.WriteLine("");
                List<CProduct> addToCart = _product.ListProducts();
                Console.WriteLine("  Which item would you like to add to your cart?");
                Console.WriteLine("1.Ceylon Tea -------------------------------- $15.00");
                Console.WriteLine("2.Assam Tea --------------------------------- $20.00");
                Console.WriteLine("3.Earl Grey Tea ----------------------------- $18.00");
                Console.WriteLine("4.Chai Tea ---------------------------------- $18.00");
                Console.WriteLine("5.Darjeeling Tea ---------------------------- $21.00");
                Console.WriteLine("6.Longjing Tea ------------------------------ $55.00");
                Console.WriteLine("7.Keemun Tea -------------------------------- $15.00");
                Console.WriteLine("8.Jasmine Tea ------------------------------- $18.00");
                Console.WriteLine("9.Matcha Tea -------------------------------- $14.00");
                Console.WriteLine("10.English Breakfast Tea -------------------- $14.00");
                Console.WriteLine("11.Rose Petal Raspberry Herbal Tea ---------- $35.00");
                Console.WriteLine("12.Blueberry Lavender Tea ------------------- $30.00");
                Console.WriteLine("13.Lemon Mint Tea --------------------------- $20.00");
                Console.WriteLine("14.Cup Set ---------------------------------- $ 6.00");
                Console.WriteLine("15.Kettle ----------------------------------- $18.00");
                Console.WriteLine("\n16. EXIT\n");
                Console.WriteLine("          Please Add Items To Your Cart");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("");
            switch(Console.ReadLine())
            {
                case "1":
                if(!shoppingCart.ContainsKey(addToCart[0]) && !shoppingCart.ContainsKey(addToCart[10])){
                    int fullCart0 = 0;
                    Console.WriteLine($@"{addToCart[0].ProductName}: {addToCart[0].ProductDescription}");
                    Console.WriteLine("\nInventory:");
                    Console.WriteLine($@"In-Store: {addToCart[0].Stock}   Online: {addToCart[10].Stock}");
                    Console.WriteLine("\nHow many would you like to buy?");
                    Console.Write("In-store: ");
                    int storeCart0 = int.Parse(Console.ReadLine());
                    Console.Write("Online: ");
                    int onlineCart0 = int.Parse(Console.ReadLine());
                    if(storeCart0 > addToCart[0].Stock || onlineCart0 > addToCart[10].Stock)
                    //TODO: add if statement to check if stock is available based on number in cart
                    fullCart0 = storeCart0 + onlineCart0;
                    fullCart += fullCart0;
                    Console.WriteLine($"{fullCart0} items have been added to your cart.");
                    // this statement is add the items in cart to what currently exists
                    shoppingCart[addToCart[0]] += storeCart0;
                    shoppingCart.Add(addToCart[0], storeCart0);
                    shoppingCart.Add(addToCart[10], onlineCart0);
                    
                    
                } else 
                {
                    Console.WriteLine("Would you like to edit your cart?");
                
                    do
                    {
                        Console.WriteLine("1.Yes");
                        Console.WriteLine("2.No");
                        switch(Console.ReadLine())
                        {
                            case "1":
                                Console.WriteLine($@"{addToCart[0].ProductName}: {addToCart[0].ProductDescription}");
                                Console.WriteLine("\nInventory:");
                                Console.WriteLine($@"In-Store: {addToCart[0].Stock}   Online: {addToCart[10].Stock}");
                                Console.WriteLine("\nHow many would you like to buy?");
                                Console.Write("In-store: ");
                                int storeCart0 = int.Parse(Console.ReadLine());
                                Console.Write("Online: ");
                                int onlineCart0 = int.Parse(Console.ReadLine());
                                int fullCart0 = storeCart0 + onlineCart0;
                                Console.WriteLine($"{fullCart0} items have been added to your cart.");
                                break;

                            case "2":
                                break;

                            default:
                                Console.WriteLine("Please enter valid response.");
                                break;

                        }
                    }while(fullCart != 0);
                
                }
                    
                break;

                case "2":
                    Console.WriteLine($@"{addToCart[1].ProductName}: {addToCart[1].ProductDescription}");
                    Console.WriteLine("\nInventory:");
                    Console.WriteLine($@"In-Store: {addToCart[1].Stock}   Online: {addToCart[11].Stock}");
                    Console.WriteLine("\nHow many would you like to buy?");
                    Console.Write("In-store: ");
                    int storeCart1 = int.Parse(Console.ReadLine());
                    Console.Write("Online: ");
                    int onlineCart1 = int.Parse(Console.ReadLine());
                    int fullCart1 = storeCart1 + onlineCart1;
                    Console.WriteLine($"{fullCart1} items have been added to your cart.");
                break;

                case "3":
                    Console.WriteLine($@"{addToCart[2].ProductName}: {addToCart[2].ProductDescription}");
                    Console.WriteLine("\nInventory:");
                    Console.WriteLine($@"In-Store: {addToCart[2].Stock}   Online: {addToCart[12].Stock}");
                    Console.WriteLine("\nHow many would you like to buy?");
                    Console.Write("In-store: ");
                    int storeCart2 = int.Parse(Console.ReadLine());
                    Console.Write("Online: ");
                    int onlineCart2 = int.Parse(Console.ReadLine());
                    int fullCart2 = storeCart2 + onlineCart2;
                    Console.WriteLine($"{fullCart2} items have been added to your cart.");
                break;

                case "4":
                    Console.WriteLine($@"{addToCart[3].ProductName}: {addToCart[3].ProductDescription}");
                    Console.WriteLine("\nInventory:");
                    Console.WriteLine($@"In-Store: {addToCart[3].Stock}   Online: {addToCart[13].Stock}");
                    Console.WriteLine("\nHow many would you like to buy?");
                    Console.Write("In-store: ");
                    int storeCart3 = int.Parse(Console.ReadLine());
                    Console.Write("Online: ");
                    int onlineCart3 = int.Parse(Console.ReadLine());
                    int fullCart3 = storeCart3 + onlineCart3;
                    Console.WriteLine($"{fullCart3} items have been added to your cart.");
                break;

                case "5":
                    Console.WriteLine($@"{addToCart[4].ProductName}: {addToCart[4].ProductDescription}");
                    Console.WriteLine("\nInventory:");
                    Console.WriteLine($@"In-Store: {addToCart[4].Stock}   Online: {addToCart[14].Stock}");
                    Console.WriteLine("\nHow many would you like to buy?");
                    Console.Write("In-store: ");
                    int storeCart4 = int.Parse(Console.ReadLine());
                    Console.Write("Online: ");
                    int onlineCart4 = int.Parse(Console.ReadLine());
                    int fullCart4 = storeCart4 + onlineCart4;
                    Console.WriteLine($"{fullCart4} items have been added to your cart.");
                break;

                case "6":
                    Console.WriteLine($@"{addToCart[5].ProductName}: {addToCart[5].ProductDescription}");
                    Console.WriteLine("\nInventory:");
                    Console.WriteLine($@"In-Store: {addToCart[5].Stock}   Online: {addToCart[15].Stock}");
                    Console.WriteLine("\nHow many would you like to buy?");
                    Console.Write("In-store: ");
                    int storeCart5 = int.Parse(Console.ReadLine());
                    Console.Write("Online: ");
                    int onlineCart5 = int.Parse(Console.ReadLine());
                    int fullCart5 = storeCart5 + onlineCart5;
                    Console.WriteLine($"{fullCart5} items have been added to your cart.");
                break;

                case "7":
                    Console.WriteLine($@"{addToCart[6].ProductName}: {addToCart[6].ProductDescription}");
                    Console.WriteLine("\nInventory:");
                    Console.WriteLine($@"In-Store: {addToCart[6].Stock}   Online: {addToCart[16].Stock}");
                    Console.WriteLine("\nHow many would you like to buy?");
                    Console.Write("In-store: ");
                    int storeCart6 = int.Parse(Console.ReadLine());
                    Console.Write("Online: ");
                    int onlineCart6 = int.Parse(Console.ReadLine());
                    int fullCart6 = storeCart6 + onlineCart6;
                    Console.WriteLine($"{fullCart6} items have been added to your cart.");
                break;

                case "8":
                    Console.WriteLine($@"{addToCart[7].ProductName}: {addToCart[7].ProductDescription}");
                    Console.WriteLine("\nInventory:");
                    Console.WriteLine($@"In-Store: {addToCart[7].Stock}   Online: {addToCart[17].Stock}");
                    Console.WriteLine("\nHow many would you like to buy?");
                    Console.Write("In-store: ");
                    int storeCart7 = int.Parse(Console.ReadLine());
                    Console.Write("Online: ");
                    int onlineCart7 = int.Parse(Console.ReadLine());
                    int fullCart7 = storeCart7 + onlineCart7;
                    Console.WriteLine($"{fullCart7} items have been added to your cart.");
                break;

                case "9":
                    Console.WriteLine($@"{addToCart[8].ProductName}: {addToCart[8].ProductDescription}");
                    Console.WriteLine("\nInventory:");
                    Console.WriteLine($@"In-Store: {addToCart[8].Stock}   Online: {addToCart[18].Stock}");
                    Console.WriteLine("\nHow many would you like to buy?");
                    Console.Write("In-store: ");
                    int storeCart8 = int.Parse(Console.ReadLine());
                    Console.Write("Online: ");
                    int onlineCart8 = int.Parse(Console.ReadLine());
                    int fullCart8 = storeCart8 + onlineCart8;
                    Console.WriteLine($"{fullCart8} items have been added to your cart.");
                break;

                case "10":
                    Console.WriteLine($@"{addToCart[9].ProductName}: {addToCart[9].ProductDescription}");
                    Console.WriteLine("\nInventory:");
                    Console.WriteLine($@"In-Store: {addToCart[9].Stock}   Online: {addToCart[19].Stock}");
                    Console.WriteLine("\nHow many would you like to buy?");
                    Console.Write("In-store: ");
                    int storeCart9 = int.Parse(Console.ReadLine());
                    Console.Write("Online: ");
                    int onlineCart9 = int.Parse(Console.ReadLine());
                    int fullCart9 = storeCart9 + onlineCart9;
                    Console.WriteLine($"{fullCart9} items have been added to your cart.");
                break;

                case "11":
                    Console.WriteLine($@"{addToCart[10].ProductName}: {addToCart[20].ProductDescription}");
                    Console.WriteLine("\nInventory:");
                    Console.WriteLine($@"In-Store: {addToCart[10].Stock}   Online: {addToCart[20].Stock}");
                    Console.WriteLine("\nHow many would you like to buy?");
                    Console.Write("In-store: ");
                    int storeCart10 = int.Parse(Console.ReadLine());
                    Console.Write("Online: ");
                    int onlineCart10 = int.Parse(Console.ReadLine());
                    int fullCart10 = storeCart10 + onlineCart10;
                    Console.WriteLine($"{fullCart10} items have been added to your cart.");
                break;

                case "12":
                    Console.WriteLine($@"{addToCart[21].ProductName}: {addToCart[21].ProductDescription}");
                    Console.WriteLine("\nInventory:");
                    Console.WriteLine($@"In-Store: Not Available   Online: {addToCart[21].Stock}");
                    Console.WriteLine("\nHow many would you like to buy?");
                    Console.Write("Online: ");
                    int onlineCart11 = int.Parse(Console.ReadLine());
                    Console.WriteLine($"{onlineCart11} items have been added to your cart.");
                break;

                case "13":
                    Console.WriteLine($@"{addToCart[22].ProductName}: {addToCart[22].ProductDescription}");
                    Console.WriteLine("\nInventory:");
                    Console.WriteLine($@"In-Store: Not Available   Online: {addToCart[22].Stock}");
                    Console.WriteLine("\nHow many would you like to buy?");
                    Console.Write("Online: ");
                    int onlineCart12 = int.Parse(Console.ReadLine());
                    Console.WriteLine($"{onlineCart12} items have been added to your cart.");
                break;

                case "14":
                    Console.WriteLine($@"{addToCart[24].ProductName}: {addToCart[24].ProductDescription}");
                    Console.WriteLine("\nInventory:");
                    Console.WriteLine($@"In-Store: Not Available   Online: {addToCart[24].Stock}");
                    Console.WriteLine("\nHow many would you like to buy?");
                    Console.Write("Online: ");
                    int onlineCart14 = int.Parse(Console.ReadLine());
                    Console.WriteLine($"{onlineCart14} items have been added to your cart.");
                break;

                case "15":
                    Console.WriteLine($@"{addToCart[25].ProductName}: {addToCart[25].ProductDescription}");
                    Console.WriteLine("\nInventory:");
                    Console.WriteLine($@"In-Store: Not Available   Online: {addToCart[25].Stock}");
                    Console.WriteLine("\nHow many would you like to buy?");
                    Console.Write("Online: ");
                    int onlineCart25 = int.Parse(Console.ReadLine());
                    Console.WriteLine($"{onlineCart25} items have been added to your cart.");
                break;

                case "16":
                    new StoreMenu().Start();
                    break;

                default:
                    Console.WriteLine("Night time");
                    break;
                }
            }while (!exit);
        }
        // TODO: Send the cart to be updated in DB (updating stock per product and adding order details)
        // You want to call CartMenu and pass the dictionary through
    }
}