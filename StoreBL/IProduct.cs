using Models;
using System.Collections.Generic;
using StoreDL;

namespace StoreBL
{
    public interface IProduct
    {
        List<CProduct> ListProducts();

        Models.CProduct changeStock(CProduct stockCount);

        List<LineItems> LinesOfItems();

        CProduct AddProduct(CProduct products);

        void createLineItem(LineItems item);
    }
}
