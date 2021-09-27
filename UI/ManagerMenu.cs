using System;
using Models;
using StoreBL;
using StoreDL;
using StoreDL.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace UI
{
    public class ManagerMenu
    {   //To start manager Menu
        public void Start()
        {
            string connectionString = File.ReadAllText(@"../connectionString.txt");
            DbContextOptions<EarlOfTeaDBContext> options = new 
            DbContextOptionsBuilder<EarlOfTeaDBContext>().UseSqlServer(connectionString).Options;
            EarlOfTeaDBContext access = new EarlOfTeaDBContext(options);

            bool exit = false;
            string input = "";
            //Need to figure out how to jump around menus
            do
            {
                Console.WriteLine("  What would you like to do? ");
                Console.WriteLine("=============================");
                Console.WriteLine(" 1. View list of Stores.");
                Console.WriteLine(" 2. Restock.");
                Console.WriteLine(" 3. Exit.");
                Console.WriteLine("=============================");

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                    Console.WriteLine("picked 1");
                    break;

                    case "2":
                    //ask for password
                    new Stocking(new ProductBL(new DBRepo(access))).Start();
                    break;

                    case "3":
                    Console.WriteLine("Exiting Window.");
                    new MainMenu().Start();
                    exit = true;
                    break;

                    default:
                    Console.WriteLine("Sorry, please select an option from above.");
                    break;
                }           
            } while (!exit);
        }
    }
}
