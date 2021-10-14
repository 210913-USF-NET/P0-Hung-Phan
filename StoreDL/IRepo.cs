using Models;
using System.Collections.Generic;

namespace StoreDL
{
    public interface IRepo
    {
        CCustomers AddCustomer(CCustomers customer);
        List<CCustomers> GetAllCustomer();

        CCustomers UpdateCustomer(CCustomers customerUpdate);

        List<CProduct> ListProducts();
        Models.CProduct changeStock(CProduct stockCount);

        CProduct showProduct(int id);
        CProduct AddProduct(CProduct products);
        List<LineItems> LinesOfItems();
        LineItems createLineItem(LineItems item);

        List<Order> OrderHistory();
    }
}