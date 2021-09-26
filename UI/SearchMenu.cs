using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI
{
    public class SearchMenu
    {
        public void Start()
        {
            bool exit = false;
            do{
                Console.WriteLine("How would you like to find your Order? ");
                Console.WriteLine("=======================================");
                Console.WriteLine(" 1. Search through Customer Account.");
                Console.WriteLine(" 2. Search through Order Number");
                Console.WriteLine(" 3. Exit.");
                Console.WriteLine("=======================================");

                switch(Console.ReadLine())
                {
                    case "1":
                    Console.WriteLine("Can't even find how im going to find this project.");
                    Console.WriteLine(" 1. Search through Customer Account.");
                    break;

                    case "2":
                    Console.WriteLine("Can't even find how im going to find this project.");
                    Console.WriteLine(" 2. Search through Order Number");
                    break;

                    case "3":
                    exit = true;
                    break;

                    default:
                    Console.WriteLine("Sorry, please select an option from above.");
                    break;
                } 
            }while (!exit);
        }
    }
}