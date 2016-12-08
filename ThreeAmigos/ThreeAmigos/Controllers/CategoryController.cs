using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeAmigos.Domain.Store;
using ThreeAmigos.Interfaces;

namespace ThreeAmigos.Controllers
{
    public class CategoryController : Controller
    {
        IStoreService _storeService;

        public CategoryController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public ActionResult Index()
        {
            IEnumerable<Category> categories = _storeService.GetAllCategories();

            return View(categories);
        }

        public ActionResult Details(int id)
        {
            //Category category = _storeService.GetCategoryById();
            throw new NotImplementedException();
        }

    }
}
