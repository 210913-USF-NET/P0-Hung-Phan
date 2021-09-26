using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using StoreDL;

namespace StoreBL
{
    public class CustomerBL : ICustomerBL
    {
        private IRepo _repo;

        public CustomerBL(IRepo repo)
        {
            _repo = repo;
        }

        public List<CCustomer> GetAllCustomer()
        {
            return _repo.GetAllCustomer();
        }

        public void AddCustomer(CCustomer customer)
        {
            _repo.AddCustomer(customer);
        }
    }
}