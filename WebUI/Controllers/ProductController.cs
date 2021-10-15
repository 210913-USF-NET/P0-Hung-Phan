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
    public class ProductController : Controller
    {
        private IProduct _bl;
        public ProductController(IProduct bl)
        {
            _bl = bl;
        }

        // GET: ProductController
        public ActionResult Items()
        {
            return View();
        }

        public ActionResult Cart()
        {
            List<LineItems> items = _bl.LinesOfItems();
            return View(items);
        }

        // GET: ProductController/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder(LineItems Buy)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.createLineItem(Buy);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }


        //GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult BuyMe()
        {
            var thisone = HttpContext.Request.Cookies["Id"];
            List<CProduct> allProduct = _bl.ListProducts();
            return View(allProduct);
        }

        //public ActionResult BuyMe(LineItems item)
        //{
        //    int ProductId = item.ProductId;
        //    int ProductQty = item.ProductQty;
        //    decimal PriceOfProduct = item.PriceOfProduct;
        //    string StoreLocation = item.StoreLocation;
        //    decimal Total = item.ProductQty * item.PriceOfProduct;

        //    return View();
        //}

        public ActionResult middleMan(int id)
        {
            HttpContext.Response.Cookies.Append("PID", id.ToString());
            //HttpContext.Response.Cookies.Append("Money", price.ToString());
            //HttpContext.Response.Cookies.Append("where", loc);
            return View(_bl.GetProductById(id));
        }


        [HttpPost]
        public ActionResult middleMan()
        {
            try
            {
                int productID = Int32.Parse(HttpContext.Request.Cookies["PID"]);
                var item = _bl.GetProductById(productID);
                //decimal currentPrice = Int32.Parse(HttpContext.Request.Cookies["currentPrice"]);
                //var currentInventory = HttpContext.Request.Cookies["currentLocation"];

                //NewCart.shoppingCart.Add(new CProduct(productID));
                return View();

            }catch
            {
                return View();
            }
        }
    }
}
