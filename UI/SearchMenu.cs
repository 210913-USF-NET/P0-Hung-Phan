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
    public class SearchMenu :IMenu
    {
        private ICustomerBL _customer;

        public SearchMenu(ICustomerBL customer)
        {
            _customer = customer;
        }
        public void Start()
        {
            bool exit = false;
            do{
                Console.WriteLine("How would you like to find your Order? ");
                Console.WriteLine("=======================================");
                Console.WriteLine(" 1. Search through Customer Account.");
                Console.WriteLine(" 2. Exit.");
                Console.WriteLine("=======================================");

                switch(Console.ReadLine())
                {
                    case "1":
                    if(matchAccount())
                    {
                    //new OrderHistory();
                    Console.WriteLine("come back when cart is done.");
                    }
                    break;

                    case "2":
                    exit = true;
                    new MainMenu().Start();
                    break;

                    default:
                    Console.WriteLine("Sorry, please select an option from above.");
                    break;
                } 
            }while (!exit);
        }

        private bool matchAccount()
        {
            bool match = false;
            string enteredUser;
            string enteredPassword;
            List<CCustomer> validAccount = _customer.GetAllCustomer();

            Console.WriteLine("\nPlease enter in your account information.");
            Console.Write("User: ");
            enteredUser = Console.ReadLine();
            Console.Write("Password: ");
            enteredPassword = Console.ReadLine();
            for( int u = 0; u <validAccount.Count; u++){
                if(enteredUser == validAccount[u].Username && enteredPassword == validAccount[u].CPassword){
                Console.WriteLine($@"Welcome {validAccount[u].CustomerName}.");
                Console.WriteLine("");
                    match = true;
                }
            }if(match == false){
                Console.WriteLine("\nUsername or Password are incorrect. Please try again.");
            }else {
                Console.WriteLine("Where would you like to shop?");
            }
            return match;
        }

/*        private void OrderHistory()
        {
            Console.WriteLine("\nPlease enter in your Order ID.");
            Console.Write("OrderID #: ");
            enteredID = Console.ReadLine();
            List<Order> history = _customer.OrderHistory();

            foreach(var order in history)
                if(order.OrderID == enteredID)
                {
                    Console.WriteLine($"{history[order].ProductID}            QTY: {history[order].QTY} at {history[order].Cost} for a Total of {history[order].Total}. Order was made for {history[order].Location}.")
                }
        }*/
    }
}
