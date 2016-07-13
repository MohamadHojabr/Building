using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.Context;
using DomainClasses.Enums;
using DomainClasses.Models;
using ServiceLayer.IService;

namespace Building.Web.Mvc.Areas.Admin.Controllers
{
    public partial class ProfileController : Controller
    {
        private IUnitOfWork _uow;
        private IProfile _profile;
        private IMainCategory _mainCategory;
        private IUsersManager _usersManager;

        public ProfileController(IUnitOfWork uow, IProfile profile, IMainCategory mainCategory, IUsersManager usersManager)
        {
            _uow = uow;
            _profile = profile;
            _mainCategory = mainCategory;
            _usersManager = usersManager;
        }

        // GET: Admin/Profile
        public virtual ActionResult PersonalProfiles()
        {
            var list = _profile.GetAll().Where(p => p.ProfileType == ProfileType.Personal);
            return View(list);
        }

        public virtual ActionResult CompanyProfiles()
        {
            var list = _profile.GetAll().Where(p => p.ProfileType == ProfileType.Company);
            return View(list);
        }

        public virtual ActionResult Create()
        {
            ViewBag.MainCategoryId = new SelectList(_mainCategory.GetAll().Where(c => c.MarkAsDelete != true), "MainCategoryId", "Name");

            ViewBag.UserId = new SelectList(_usersManager.GetAllUsers(), "Id", "UserName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(Profile profile)
        {
            if (ModelState.IsValid)
            {
                _profile.AddOrUpdate(profile);
                _uow.SaveChanges();
                return RedirectToAction("PersonalProfiles");
            }
            return View(profile);
        }


    }
}