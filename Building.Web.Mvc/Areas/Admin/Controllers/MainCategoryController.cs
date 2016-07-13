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
    public partial class MainCategoryController : Controller
    {
        private IUnitOfWork _uow;
        private IMainCategory _mainCategory;

        public MainCategoryController(IUnitOfWork uow, IMainCategory mainCategory)
        {
            _uow = uow;
            _mainCategory = mainCategory;
        }

        // GET: Admin/MainCategory
        public virtual ActionResult Index()
        {
            ViewBag.list = _mainCategory.GetAll();

            var list = _mainCategory.GetAll().Where(c => c.ParentId == null);
            return View(list);
        }

        public virtual ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return RedirectToAction("BadRequest", "Error", new { area = "" });
            }
            var model = _mainCategory.Find(id);
            if (model == null)
            {
                return RedirectToAction("NotFound", "Error", new { area = "" });
            }
            return View(model);
        }

        public virtual ActionResult Create(string id)
        {
            ViewBag.CatId = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(MainCategory mainCategory)
        {
            if (ModelState.IsValid)
            {
                _mainCategory.AddOrUpdate(mainCategory);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mainCategory);
        }

        public virtual ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return RedirectToAction("BadRequest", "Error", new { area = "" });
            }
            var model = _mainCategory.Find(id);
            if (model == null)
            {
                return RedirectToAction("NotFound", "Error", new { area = "" });
            }
            ViewBag.ParentId = new SelectList(_mainCategory.GetAll(), "MainCategoryId", "Name", model.ParentId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit([Bind(Include = "MainCategoryId,Name,Describtion,ParentId")] MainCategory mainCategory)
        {
            if (ModelState.IsValid)
            {
                _mainCategory.AddOrUpdate(mainCategory);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentId = new SelectList(_mainCategory.GetAll(), "MainCategoryId", "Name");
            return View(mainCategory);
        }

        public virtual ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return RedirectToAction("BadRequest", "Error", new { area = "" });
            }
            var model = _mainCategory.Find(id);
            if (model == null)
            {
                return RedirectToAction("NotFound", "Error", new { area = "" });
            }
            if (model.ParentId == null)
            {
                return RedirectToAction("BadRequest", "Error", new { area = "" });
            }

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(Guid id)
        {
            var model = _mainCategory.Find(id);
            _mainCategory.Delete(model);
            _uow.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}