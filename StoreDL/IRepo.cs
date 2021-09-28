using Models;
using System.Collections.Generic;

namespace StoreDL
{
    public interface IRepo
    {

        CCustomer AddCustomer(CCustomer customer);
        List<CCustomer> GetAllCustomer();

        List<CProduct> ListProducts();
        Models.CProduct changeStock(CProduct stockCount);

        List<LineItems> LinesOfItems();
        LineItems createLineItem(LineItems item);

        List<Order> OrderHistory();


    }
}