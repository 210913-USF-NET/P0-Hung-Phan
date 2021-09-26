using System;
using Models;
using StoreBL;
using StoreDL;
using StoreDL.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace UI
{
    class StoreMenu : IMenu
    {
        //start() for begin the console app 
        public void Start()
        {//made an empty string for user's choice for menu and set exit to false
            string connectionString = File.ReadAllText(@"../connectionString.txt");
            DbContextOptions<EarlOfTeaDBContext> options = new 
            DbContextOptionsBuilder<EarlOfTeaDBContext>().UseSqlServer(connectionString).Options;
            EarlOfTeaDBContext next = new EarlOfTeaDBContext(options);
            
            bool exit = false;
            string input = "";

            //Need to figure out how to jump around menus
            do
            {
                Console.WriteLine("\nWhere would you like to go? ");
                Console.WriteLine("===========================");
                Console.WriteLine(" 1. My Cart.");
                Console.WriteLine(" 2. Shopping.");
                Console.WriteLine(" 3. Exit.");
                Console.WriteLine("===========================");
                //Allow user to pick which Menu they want to go to next
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        new CartMenu().Start();
                        break;

                    case "2": 
                        new OnlineInventory(new ProductBL(new DBRepo(next))).Start();
                        break;

                    case "3": // Makes exit true and thanks them to visiting
                        Console.WriteLine("Thank you for visit, hope to see you again soon!");
                        exit = true;
                        break;

                    default: //When user enter in a value that wasn't listed above
                        Console.WriteLine("Sorry, please select an option from above.");
                        break;
                }           
            } while (!exit);
        }
    }
}