using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using StoreDL;

namespace StoreBL
{
    public class ProductBL : IProduct
    {
        private IRepo _repo;

        public ProductBL(IRepo repo)
        {
            _repo = repo;
        }

        public List<CProduct> ListProducts()
        {
            return _repo.ListProducts();
        }

        public void changeStock(CProduct stockCount)
        {
            _repo.changeStock(stockCount);
        }
    }
}
