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
    public class CustomerMenu : IMenu
    {
        //connect and pass things with IBL
        private ICustomerBL _customer;

        public CustomerMenu(ICustomerBL customer)
        {
            _customer = customer;
        }

        //Layout for the Customer Start Menu using a do while loop to display opinions and nested a switch case to select opinion
        //Still need to figure out how to jump around menus
        public void Start()
        {
            bool exit = false;
            //string fakeuser = "user";
            //string fakepassword = "pass";

            do
            {
                Console.WriteLine("\n    How can we help you? ");
                Console.WriteLine("===========================");
                Console.WriteLine(" 1. Sign-In");
                Console.WriteLine(" 2. Make New Username");
                Console.WriteLine(" 3. Exit.");
                Console.WriteLine("===========================\n");

                switch (Console.ReadLine())
                {
                    case "1":
                        //make while loop for checking passwords
                        if(matchAccount())
                        {
                        new StoreMenu().Start();
                        }
                        break;

                    case "2":
                        //making a new customer user
                        AddCustomer();
                        new StoreMenu().Start();
                        break;

                    case "3":
                        Console.WriteLine("Thank you for visit, hope to see you again soon!");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Sorry, please select an option from above.");
                        break;
                }
            } while (!exit);
        }
        //For customer to create an User
        private void AddCustomer()
        {
            List<CCustomer> validAccount = _customer.GetAllCustomer();

            Console.Write("Please enter your name: ");
            string cName = Console.ReadLine();
            Console.Write("Please enter desired username: ");
            string newUser = Console.ReadLine();

            foreach(var user in validAccount){
                if(user.Username == newUser){
                    Console.WriteLine("This username already exists.");
                    AddCustomer();
                }
            }

            Console.Write("Please make a password: ");
            string newPassword = Console.ReadLine();


            Models.CCustomer customer = new Models.CCustomer(cName, newUser, newPassword);
            _customer.AddCustomer(customer);
            Console.WriteLine($"\nWelcome, {customer.ToString()}. Your Account ID is {customer.CustomerId}");
        
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
    }
}
