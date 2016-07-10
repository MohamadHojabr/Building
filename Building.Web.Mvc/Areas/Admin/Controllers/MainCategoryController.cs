using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.Context;
using DomainClasses.Models;
using ServiceLayer.IService;

namespace Building.Web.Mvc.Areas.Admin.Controllers
{
    public class MainCategoryController : Controller
    {
        private IUnitOfWork _uow;
        private IMainCategory _mainCategory;

        public MainCategoryController(IUnitOfWork uow, IMainCategory mainCategory)
        {
            _uow = uow;
            _mainCategory = mainCategory;
        }

        // GET: Admin/MainCategory
        public ActionResult Index()
        {
            ViewBag.list = _mainCategory.GetAll();

            var list = _mainCategory.GetAll().Where(c=>c.ParentId == null);
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create( MainCategory mainCategory)
        {
            if (ModelState.IsValid)
            {
                _mainCategory.AddOrUpdate(mainCategory);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mainCategory);
        }

    }
}