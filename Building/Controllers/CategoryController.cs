using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.Context;
using ServiceLayer.IService;

namespace Building.Controllers
{
    public class CategoryController : Controller
    {
        private IUnitOfWork _uow;
        private ICategoryService _categoryService;

        public CategoryController(IUnitOfWork uow, ICategoryService categoryService)
        {
            _uow = uow;
            _categoryService = categoryService;
        }

        // GET: Category
        public ActionResult Index()
        {
            var list = _categoryService.GetAllCategory();
            return View(list);
        }
    }
}