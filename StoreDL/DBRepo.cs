using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = Models;
using Entity = StoreDL.Entities;
using Microsoft.EntityFrameworkCore;

namespace StoreDL
{
    public class DBRepo : IRepo
    {
        private Entity.EarlOfTeaDBContext _context;

        public DBRepo()
        {
        }

        public DBRepo(Entity.EarlOfTeaDBContext context)
        {
            _context = context;
        }

        public Model.CCustomer AddCustomer(Model.CCustomer customer)
        {
            Entity.Customer newCustomerID = new Entity.Customer()
            {
                CustomerName = customer.CustomerName,
                Username = customer.Username,
                CPassword = customer.CPassword
            };

            newCustomerID = _context.Add(newCustomerID).Entity;

            _context.SaveChanges();

            _context.ChangeTracker.Clear();

            return new Model.CCustomer()
            {
                CustomerId = newCustomerID.CustomerId,
                CustomerName = newCustomerID.CustomerName,
                Username = newCustomerID.Username,
                CPassword = newCustomerID.CPassword
            };
        }

        public List<Model.CCustomer> GetAllCustomer()
        {
            return _context.Customers.Select(
                customer => new Model.CCustomer(){
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.CustomerName,
                    Username = customer.Username,
                    CPassword = customer.CPassword
                }
            ).ToList();
        } 

        public List<Model.CProduct> ListProducts()
        {
            return _context.Products.Select(
                products => new Model.CProduct(){
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

        public Model.CProduct changeStock(Model.CProduct stockCount)
        {
            Entity.Product newCount = (from s in _context.Products 
                where s.ProductId == stockCount.ProductId
                select s).SingleOrDefault();
                Console.WriteLine(newCount);

            newCount.Stock = stockCount.Stock;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.CProduct(){
                Stock = stockCount.Stock
            };
        }

        public List<Model.LineItems> LinesOfItems()
        {
            return _context.Products.Select(
                items => new Model.LineItems(){
                    ProductId = items.ProductId
                }
            ).ToList();
        }

        public Model.LineItems createLineItem(Model.LineItems item)
        {
            Entity.OrderDetail lines = new Entity.OrderDetail()
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

            return new Model.LineItems()
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

        public List<Model.Order> OrderHistory()
        {
            return _context.OrderDetails.Select(
                orders => new Model.Order()
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