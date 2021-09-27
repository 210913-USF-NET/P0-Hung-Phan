using Models;
using System.Collections.Generic;

namespace StoreDL
{
    public interface IRepo
    {

        CCustomer AddCustomer(CCustomer customer);
        List<CCustomer> GetAllCustomer();

        List<CProduct> ListProducts();
        CProduct changeStock(CProduct stockCount);


    }
}