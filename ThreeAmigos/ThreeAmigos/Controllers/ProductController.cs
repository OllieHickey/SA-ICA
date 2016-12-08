using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeAmigos.Converters;
using ThreeAmigos.Domain.Store;
using ThreeAmigos.Interfaces;
using ThreeAmigos.Models;

namespace ThreeAmigos.Controllers
{
    public class ProductController : Controller
    {
        IStoreService _storeService;

        public ProductController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public ActionResult Index()
        {
            var products = _storeService.GetAllProducts().Select(x => Converter.ToProductViewModel(x));

            return View(products);
        }

        public ActionResult Details(int id)
        {
            var product = Converter.ToProductViewModel(_storeService.GetProductById(id));

            return View(product);
        }

        public PartialViewResult ProductsByMinMaxPrice(string minPrice = null, string maxPrice = null)
        {
            var products = _storeService.GetProductsBySearch(null, null, Decimal.Parse(minPrice), Decimal.Parse(maxPrice)).Select(x => Converter.ToProductViewModel(x));

            return PartialView("_productTable", products);
        }
    }
}
