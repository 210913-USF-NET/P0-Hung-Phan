using System;
using Models;
using StoreBL;
using StoreDL;
using System.Collections.Generic;
using StoreDL.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace UI
{
    public class LookupCustomer : IMenu
    {
        private ICustomerBL _customer;

        public LookupCustomer(ICustomerBL customer)
        {
            _customer = customer;
        }
        public void Start(){
            bool exit = false;
            string input = "";
            do
            {
            Console.WriteLine("What you like to do?");
            Console.WriteLine("1. Find Customer's Username and Password");
            Console.WriteLine("2. Exit.");
            input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    findCustomer();
                    break;
                
                case "2":
                    new MainMenu().Start();
                    break;
                
                default:
                Console.WriteLine("Sorry, please select an option from above.");
                break;
            }
        }while (!exit);
        }

        private bool findCustomer()
        {
            bool exit = false;
            List<CCustomer> findThem = _customer.GetAllCustomer();
            Console.Write("Please enter customer's Name: ");
            string cName = Console.ReadLine();
            foreach(var u in findThem)
            {
                if(u.CustomerName == cName)
                {
                    Console.WriteLine($"Username: {u.Username}  Password: {u.CPassword}");
                }
                exit = true;
            }
            return exit;
        }
    }
}