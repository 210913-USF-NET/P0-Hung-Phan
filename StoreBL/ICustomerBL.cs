using Models;
using System.Collections.Generic;
using StoreDL;

namespace StoreBL
{
    public interface ICustomerBL
    {
        void AddCustomer(CCustomer customer);

        List<CCustomer> GetAllCustomer();
    }
}