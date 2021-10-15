using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreBL;
using Models;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProduct _bl;
        public CartController(IProduct bl)
        {
            _bl = bl;
        }
        public ActionResult Index()
        {
            return View(NewCart.shoppingCart);
        }

        public ActionResult CompleteOrder()
        {
            int MyCustomerId = Int32.Parse(HttpContext.Request.Cookies["Id"]);
            foreach (CProduct i in NewCart.shoppingCart)
            {
                LineItems pleaseWork = new LineItems()
                {
                    ProductID = i.ComebackProductId(),
                    PriceOfProduct = i.ComebackPrice(),
                    StoreLocation = i.ComebackInventory(),
                    CustomerId = MyCustomerId
                };
                _bl.createLineItem(pleaseWork);
                _bl.changeStock(i);
            }
            NewCart.shoppingCart.Clear();
            return RedirectToAction("BuyMe", "Product");
        }
    }
}
