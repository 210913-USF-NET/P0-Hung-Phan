using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreBL;
using Models;


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

    }
}
