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
        public ActionResult Index()
        {
            List<CProduct> allProduct = _bl.ListProducts();
            return View(allProduct);
        }

        public ActionResult ItemPage()
        {
            return View();
        }

        public ActionResult Ceylon()
        {
            List<CProduct> allProduct = _bl.ListProducts();
            return View(allProduct);
        }
        public ActionResult Assam()
        {
            List<CProduct> allProduct = _bl.ListProducts();
            return View(allProduct);
        }
        public ActionResult EarlGrey()
        {
            List<CProduct> allProduct = _bl.ListProducts();
            return View(allProduct);
        }
        public ActionResult Chai()
        {
            List<CProduct> allProduct = _bl.ListProducts();
            return View(allProduct);
        }

        public ActionResult BlueberryLavender()
        {
            List<CProduct> allProduct = _bl.ListProducts();
            return View(allProduct);
        }

        public ActionResult LemonMint()
        {
            List<CProduct> allProduct = _bl.ListProducts();
            return View(allProduct);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CProduct product)
        {
            try
            {
               if(ModelState.IsValid)
                {
                    _bl.AddProduct(product);
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
    }
}
