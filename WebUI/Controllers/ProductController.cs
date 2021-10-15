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

        public ActionResult BuyMe()
        {
            var checkForUser = HttpContext.Request.Cookies["Id"];
            if (checkForUser != null)
            {
                ViewData["user"] = "yes";
            }
            var thisone = HttpContext.Request.Cookies["Id"];
            List<CProduct> allProduct = _bl.ListProducts();
            allProduct = allProduct.OrderBy(q => q.ProductId).ToList();
            return View(allProduct);
        }

        public ActionResult middleMan(int id)
        {
            HttpContext.Response.Cookies.Append("PID", id.ToString());
            return View(_bl.GetProductById(id));
        }


        [HttpPost]
        public ActionResult middleMan()
        {
            try
            {
                int productID = Int32.Parse(HttpContext.Request.Cookies["PID"]);
                var item = _bl.GetProductById(productID);
                decimal currentPrice = item.Price;
                var currentInventory = item.InventoryLocation;
                var currentName = item.ProductName;

                NewCart.shoppingCart.Add(new CProduct(productID, currentPrice, currentInventory, currentName));
                return RedirectToAction(nameof(BuyMe));

            }catch
            {
                return RedirectToAction(nameof(BuyMe));
            }
        }
    }
}
