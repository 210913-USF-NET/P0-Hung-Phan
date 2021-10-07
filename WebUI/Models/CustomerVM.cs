using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Models;

namespace WebUI.Models
{
    public class CustomerVM
    {
        public CustomerVM() { }

        public CustomerVM(CCustomers customer)
        {
            this.CustomerId = customer.CustomerId;
            this.CustomerName = customer.CustomerName;
            this.Username = customer.Username;
            this.CPassword = customer.CPassword;
        }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string CPassword { get; set; }

        public CCustomers ToModel()
        {
            return new CCustomers
            {
                CustomerId = this.CustomerId,
                CustomerName = this.CustomerName,
                Username = this.Username,
                CPassword = this.CPassword
            };
        }
        public string ConfirmPassword { get; set; }

    }
}
