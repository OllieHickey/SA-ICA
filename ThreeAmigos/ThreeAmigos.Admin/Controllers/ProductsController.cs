using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeAmigos.Domain.Store;
using ThreeAmigos.Interfaces;
using ThreeAmigos.Services.Store;

namespace ThreeAmigos.Admin.Controllers
{
    public class ProductsController : Controller
    {
        //
        // GET: /Products/
        IStoreService _storeData;

        public ActionResult Index()
        {

            IEnumerable<Product> products = _storeData.GetAllProducts();
            return View();
        }

        //
        // GET: /Products/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // POST: /Products/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
