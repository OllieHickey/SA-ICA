using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeAmigos.Domain.Store;
using ThreeAmigos.Interfaces;
using ThreeAmigos.Models;
using ThreeAmigos.Converters;

namespace ThreeAmigos.Controllers
{
    public class BrandController : Controller
    {
        IStoreService _storeService;

        public BrandController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public ActionResult Index()
        {
            IEnumerable<BrandViewModel> brands = _storeService.GetAllBrands().Select(x => Converter.ToBrandViewModel(x));

            return View(brands);
        }

        public ActionResult Details(int id)
        {
            Brand brand = _storeService.GetBrandById(id);
            IEnumerable<ProductViewModel> products = _storeService.GetAllProducts().Select(x => Converter.ToProductViewModel(x));

            BrandViewModel finalBrand = Converter.ToBrandViewModel(brand, products);

            return View(finalBrand);
        }


    }
}
