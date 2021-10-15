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
            CProduct tempProduct = GetProductById(stockCount.ProductId);
            tempProduct.Stock -= 1;

            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new CProduct();
        }

        public List<LineItems> LinesOfItems()
        {
            return _context.Products.Select(
                items => new LineItems(){
                    ProductID = items.ProductId
                }
            ).ToList();
        }

        public LineItems createLineItem(LineItems item)
        {
            Random randId = new Random();
            Order lines = new Order()
            {
                OrderID = randId.Next(1, 1000000),
                ProductID = item.ProductID,
                QTY = 1,
                Cost = item.PriceOfProduct,
                Location = item.StoreLocation,
                Total = item.PriceOfProduct,
                CustomerId = item.CustomerId
            };

            lines = _context.Add(lines).Entity;
            _context.SaveChanges();

            return new LineItems()
            {
                OrderID = lines.OrderID,
                ProductID = lines.ProductID,
                ProductQty = 1,
                PriceOfProduct = lines.Cost,
                StoreLocation = lines.Location,
                Total = item.PriceOfProduct,
                CustomerId = lines.CustomerId
            };
        }

        public List<Order> OrderHistory()
        {
            return _context.OrderDetails.Select(
                orders => new Order()
                {
                    OrderID = orders.OrderID,
                    ProductID = orders.ProductID,
                    QTY = orders.QTY,
                    Cost = orders.Cost,
                    Location = orders.Location,
                    Total = orders.Total,
                    CustomerId = orders.CustomerId
                }
            ).ToList();
        }

        public CProduct GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }

    }
}