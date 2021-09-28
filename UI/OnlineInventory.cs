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
using System.Text.Json;
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
            Dictionary<int, int> shoppingCart = new Dictionary<int, int>();
            List<LineItems> items = _product.LinesOfItems();

            bool exit = false;
            int fullCart = 0;
            var rnd = new Random();
            int OrderNum = rnd.Next(10000);
            int cid = 1;

            do
            {
                Console.WriteLine("");
                List<CProduct> addToCart = _product.ListProducts();
                Console.WriteLine("  Which item would you like to add to your cart?");
                Console.WriteLine("1.Ceylon Tea -------------------------------------- $15.00");
                Console.WriteLine("2.Assam Tea --------------------------------------- $20.00");
                Console.WriteLine("3.Earl Grey Tea ----------------------------------- $18.00");
                Console.WriteLine("4.Chai Tea ---------------------------------------- $18.00");
                Console.WriteLine("5.Darjeeling Tea ---------------------------------- $21.00");
                Console.WriteLine("6.Longjing Tea ------------------------------------ $55.00");
                Console.WriteLine("7.Keemun Tea -------------------------------------- $15.00");
                Console.WriteLine("8.Jasmine Tea ------------------------------------- $18.00");
                Console.WriteLine("9.Matcha Tea -------------------------------------- $14.00");
                Console.WriteLine("10.English Breakfast Tea -------------------------- $14.00");
                Console.WriteLine("11.Rose Petal Raspberry Herbal Tea (Online Only) -- $35.00");
                Console.WriteLine("12.Blueberry Lavender Tea (Online Only) ----------- $30.00");
                Console.WriteLine("13.Lemon Mint Tea (Online Only) ------------------- $20.00");
                Console.WriteLine("14.Cup Set (Online Only) -------------------------- $ 6.00");
                Console.WriteLine("15.Kettle (Online Only) --------------------------- $18.00");
                Console.WriteLine("Would you like to shop online or pick up in store?");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("1. Online");
                Console.WriteLine("2. In-Store"); 
                Console.WriteLine("3. Check Out");
                Console.WriteLine("4. Exit"); 
                Console.WriteLine("");
            switch(Console.ReadLine())
            {
                case "1":
                    int lookup = 0;
                    Console.Write("Pick a product to look at: ");
                    lookup = int.Parse(Console.ReadLine()) + 9;
                    if(lookup > 24 || lookup < 9){
                        Console.WriteLine("Please enter valid opinion.");
                    }
                    if(!shoppingCart.ContainsKey(lookup))
                    {
                        Console.WriteLine($@"{addToCart[lookup].ProductName}: {addToCart[lookup].ProductDescription}");
                        Console.WriteLine("\nInventory:");
                        string loc = addToCart[lookup].InventoryLocation;
                        Console.WriteLine($@"{loc}: {addToCart[lookup].Stock}");
                        Console.WriteLine("How many would you like to buy?");
                        int storeCart = int.Parse(Console.ReadLine());
                        if(storeCart > addToCart[lookup].Stock)
                            {
                                Console.WriteLine("Sorry, but we can not fulfill your order.");
                                storeCart = 0;
                            }
                        fullCart += storeCart;
                        decimal On_total = storeCart*addToCart[lookup].Price;
                        Console.WriteLine($@"You have add {storeCart} {addToCart[lookup].ProductName} into your cart.");

                        Models.LineItems buyMe = new Models.LineItems(OrderNum, addToCart[lookup].ProductId, storeCart, addToCart[lookup].Price, loc, On_total, cid);
                        _product.createLineItem(buyMe);

                    }else
                    {
                        Console.WriteLine("Would you like to change what you have in the cart?");
                        Console.WriteLine("1. Yes");
                        Console.WriteLine("2. No"); 

                        switch(Console.ReadLine())
                        {
                            case "1":
                                Console.WriteLine($@"{addToCart[lookup].ProductName}: {addToCart[lookup].ProductDescription}");
                                Console.WriteLine("\nInventory:");
                                Console.WriteLine($@"{addToCart[lookup].InventoryLocation}: {addToCart[lookup].Stock}");
                                string loc = addToCart[lookup].InventoryLocation;
                                Console.WriteLine("How many would you like to buy? *Please enter in new amount! This will replace not -/+ to current amount!*");
                                int storeCart = int.Parse(Console.ReadLine());
                                    if(storeCart > addToCart[lookup].Stock)
                                    {
                                        Console.WriteLine("Sorry, but we can not fulfill your order.");
                                        storeCart = 0;
                                    }
                            fullCart += storeCart;
                            shoppingCart[lookup] = storeCart;
                            decimal On_total = storeCart*addToCart[lookup].Price;
                            Console.WriteLine($@"You have updated you cart to have {storeCart} {addToCart[lookup].ProductName}.");
                            Models.LineItems buyMe = new Models.LineItems(OrderNum, addToCart[lookup].ProductId, storeCart, addToCart[lookup].Price, loc, On_total, cid);
                            _product.createLineItem(buyMe);
                            break;

                            case "2":
                                break;

                            default:
                                Console.WriteLine("Please enter a valid response.");
                                break;
                        }
                    }
                    break;
                    /*
                case "2":
                    int pickup = 0;
                    Console.Write("Pick a product to look at: ");
                    pickup = int.Parse(Console.ReadLine()) - 1;
                    if(pickup < 15 && pickup > 10){
                        Console.WriteLine("These products are online only if you would like to order them please go back and pick online.");
                    }else if( pickup < 0 || pickup > 14)
                    {
                        Console.WriteLine("Please enter valid opinion.");
                    }
                    if(!shoppingCart.ContainsKey(pickup))
                    {
                        Console.WriteLine($@"{addToCart[pickup].ProductName}: {addToCart[pickup].ProductDescription}");
                        Console.WriteLine("\nInventory:");
                        Console.WriteLine($@"In-Store: {addToCart[pickup].Stock}");
                        Console.WriteLine("How many would you like to buy?");
                        int storeCart = int.Parse(Console.ReadLine());
                        if(storeCart > addToCart[pickup].Stock)
                            {
                                Console.WriteLine("Sorry, but we can not fulfill your order.");
                                storeCart = 0;
                            }
                        fullCart += storeCart;
                        shoppingCart.Add(pickup, storeCart);
                        foreach(KeyValuePair<int, int> kvp in shoppingCart)
                        {
                            Console.WriteLine("Key = {0}, Value = {1}",
                            kvp.Key, kvp.Value);
                        }
                        Console.WriteLine($@"You have add {storeCart} {addToCart[pickup].ProductName} into your cart.");

                    }else
                    {
                        Console.WriteLine("Would you like to change what you have in the cart?");
                        Console.WriteLine("1. Yes");
                        Console.WriteLine("2. No"); 

                        switch(Console.ReadLine())
                        {
                            case "1":
                                Console.WriteLine($@"{addToCart[pickup].ProductName}: {addToCart[pickup].ProductDescription}");
                                Console.WriteLine("\nInventory:");
                                Console.WriteLine($@"Online Store: {addToCart[pickup].Stock}");
                                Console.WriteLine("How many would you like to buy? *Please enter in new amount! This will replace not -/+ to current amount!*");
                                int storeCart = int.Parse(Console.ReadLine());
                                    if(storeCart > addToCart[pickup].Stock)
                                    {
                                        Console.WriteLine("Sorry, but we can not fulfill your order.");
                                        storeCart = 0;
                                    }
                            fullCart += storeCart;
                            shoppingCart[pickup] = storeCart;
                            foreach(KeyValuePair<int, int> kvp in shoppingCart)
                            {
                                Console.WriteLine("Key = {0}, Value = {1}",
                                kvp.Key, kvp.Value);
                            }
                            Console.WriteLine($@"You have updated you cart to have {storeCart} {addToCart[pickup].ProductName}.");
                            break;

                            default:
                                Console.WriteLine("Please enter a valid response.");
                                break;
                        }
                    }
                break;

                case "3":
                break;
*/
                case "4":
                    Console.WriteLine("Exiting will cause you to empty your cart. Do you like to continue?");
                    Console.WriteLine("1. Yes");
                    Console.WriteLine("2. No");
                    switch(Console.ReadLine())
                    {
                        case "1":
                            new MainMenu().Start();
                            break;

                        case "2":
                            break;

                        default:
                            Console.WriteLine("Please enter valid opinion.");
                            break;
                    }
                break;

                default:
                Console.WriteLine("Please pick an opinion above.");
                break;

                }
            }while (!exit);
        }
        // TODO: Send the cart to be updated in DB (updating stock per product and adding order details)
        // You want to call CartMenu and pass the dictionary through
    }
}