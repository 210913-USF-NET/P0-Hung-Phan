using System;
using System.Collections.Generic;

namespace Models
{
    public class CCustomer
    {
        //Constructor for Customer 
        public CCustomer(){
        }
        //Constructor overloading
        public CCustomer(string name) : this()
        {      
            this.CustomerName = name;
        }

        public CCustomer(int id) : this()
        {      
            this.CustomerId = id;
        }

        //Constructor Chain to add on user if Customer wants to add user
        public CCustomer(string name, string user, string password) : this(name)
        {
            this.Username = user;
            this.CPassword = password;
        }

        //Properties for name, user
        public int CustomerId{get; set;}

        public string CustomerName {get; set;}

        public string Username {get; set;}

        public string CPassword {get; set;}

        public override string ToString()
        {
            return $"Name: {this.CustomerName}, Username: {this.Username}";
        }
    }
}
