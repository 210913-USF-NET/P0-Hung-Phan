using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Microsoft.EntityFrameworkCore;

namespace StoreDL
{
    public class DBRepo : IRepo
    {
        private StoreDBContext _context;

        public DBRepo()
        {
        }

        public DBRepo(StoreDBContext context)
        {
            _context = context;
        }

        public CCustomers AddCustomer(CCustomers customer)
        {
            CCustomers newCustomerID = new()
            {
                CustomerName = customer.CustomerName,
                Username = customer.Username,
                CPassword = customer.CPassword
            };

            newCustomerID = _context.Add(newCustomerID).Entity;

            _context.SaveChanges();

            _context.ChangeTracker.Clear();

            return new CCustomers()
            {
                CustomerId = newCustomerID.CustomerId,
                CustomerName = newCustomerID.CustomerName,
                Username = newCustomerID.Username,
                CPassword = newCustomerID.CPassword
            };
        }

        public List<CCustomers> GetAllCustomer()
        {
            return _context.Customers.Select(
                customer => new CCustomers(){
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.CustomerName,
                    Username = customer.Username,
                    CPassword = customer.CPassword
                }
            ).ToList();
        } 

        public CCustomers FindCustomer(int id)
        {
            return _context.Customers.AsNoTracking().FirstOrDefault(c => c.CustomerId == id);
        }

        public CCustomers UpdateCustomer(CCustomers customerUpdate)
        {
            CCustomers newCustomer = new CCustomers()
            {
                CustomerId = customerUpdate.CustomerId,
                CustomerName = customerUpdate.CustomerName,
                Username = customerUpdate.Username,
                CPassword = customerUpdate.CPassword
            };

            newCustomer = _context.Customers.Update(newCustomer).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new CCustomers()
            {
                CustomerId = newCustomer.CustomerId,
                CustomerName = newCustomer.CustomerName,
                Username = newCustomer.Username,
                CPassword = newCustomer.CPassword
            };

        }

        public CProduct AddProduct(CProduct products)
        {
            CProduct newProduct = new()
            {
                ProductId = products.ProductId,
                ProductName = products.ProductName,
                ProductDescription = products.ProductDescription,
                Price = products.Price,
                InventoryLocation = products.InventoryLocation,
                Stock = products.Stock,
                Category = products.Category
            };

            newProduct = _context.Add(newProduct).Entity;

            _context.SaveChanges();

            _context.ChangeTracker.Clear();

            return new CProduct()
            {
                ProductId = newProduct.ProductId,
                ProductName = newProduct.ProductName,
                ProductDescription = newProduct.ProductDescription,
                Price = newProduct.Price,
                InventoryLocation = newProduct.InventoryLocation,
                Stock = newProduct.Stock,
                Category = newProduct.Category
            };
        }

        public List<CProduct> ListProducts()
        {
            return _context.Products.Select(
                products => new CProduct(){
                    ProductId = products.ProductId,
                    ProductName = products.ProductName,
                    ProductDescription = products.ProductDescription,
                    Price = products.Price,
                    InventoryLocation = products.InventoryLocation,
                    Stock = products.Stock,
                    Category = products.Category
                }
            ).ToList();
        }

        public CProduct showProduct(int id)
        {
            return _context.Products.AsNoTracking().FirstOrDefault(p => p.ProductId == id);
        }

        public CProduct changeStock(CProduct stockCount)
        {
            CProduct newCount = (from s in _context.Products 
                where s.ProductId == stockCount.ProductId
                select s).SingleOrDefault();

            newCount.Stock = stockCount.Stock;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new CProduct(){
                Stock = stockCount.Stock
            };
        }

        public List<LineItems> LinesOfItems()
        {
            return _context.Products.Select(
                items => new LineItems(){
                    ProductId = items.ProductId
                }
            ).ToList();
        }

        public LineItems createLineItem(LineItems item)
        {
            Order lines = new Order()
            {
                OrderId = item.OrderId,
                ProductId = item.ProductId,
                ProductQty = item.ProductQty,
                PriceOfProduct = item.PriceOfProduct,
                StoreLocation = item.StoreLocation,
                Total = item.Total,
                CustomerId = item.CustomerId
            };

            lines = _context.Add(lines).Entity;
            _context.SaveChanges();

            return new LineItems()
            {
                OrderId = lines.OrderId,
                ProductId = lines.ProductId,
                ProductQty = lines.ProductQty,
                PriceOfProduct = lines.PriceOfProduct,
                StoreLocation = lines.StoreLocation,
                Total = lines.Total,
                CustomerId = lines.CustomerId
            };
        }

        public List<Order> OrderHistory()
        {
            return _context.OrderDetails.Select(
                orders => new Order()
                {
                    ID = orders.OrderDetailsId,
                    OrderID = orders.OrderId,
                    ProductID = orders.ProductId,
                    QTY = orders.ProductQty,
                    Cost = orders.PriceOfProduct,
                    Location = orders.StoreLocation,
                    Total = orders.Total,
                    CustomerId = orders.CustomerId
                }
            ).ToList();
        }
    }
}