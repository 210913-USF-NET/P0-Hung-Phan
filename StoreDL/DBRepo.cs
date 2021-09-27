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
            Entity.Product newStockCount = new Entity.Product()
            {
                    Stock = stockCount.Stock,
            };

            newStockCount = _context.Update(newStockCount).Entity;

            _context.SaveChanges();

            _context.ChangeTracker.Clear();

            return new Model.CProduct()
            {
                    ProductId = newStockCount.ProductId,
                    ProductName = newStockCount.ProductName,
                    ProductDescription = newStockCount.ProductDescription,
                    Price = newStockCount.Price,
                    InventoryLocation = newStockCount.InventoryLocation,
                    Stock = newStockCount.Stock,
                    Category = newStockCount.Category
            };
        } 

        public List<Model.Order> OrderHistory()
        {
            return _context.OrderDetails.Select(
                orders => new Model.Order()
                {
                    OrderID = orders.OrderId,
                    ProductID = orders.ProductId,
                    QTY = orders.ProductQty,
                    Cost = orders.PriceOfProduct,
                    Location = orders.StoreLocation,
                    Total = orders.Total,
                    customerID = orders.Customer_Id
                }
            ).ToList();
        }
    }
}