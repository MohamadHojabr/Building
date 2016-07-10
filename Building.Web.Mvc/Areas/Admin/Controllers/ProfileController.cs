using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.Context;
using DomainClasses.Enums;
using ServiceLayer.IService;

namespace Building.Web.Mvc.Areas.Admin.Controllers
{
    public class ProfileController : Controller
    {
        private IUnitOfWork __uow;
        private IProfile _profile;
        private IMainCategory _mainCategory;

        public ProfileController(IUnitOfWork uow, IProfile profile, IMainCategory mainCategory)
        {
            __uow = uow;
            _profile = profile;
            _mainCategory = mainCategory;
        }

        // GET: Admin/Profile
        public ActionResult PersonalProfiles()
        {
            var list = _profile.GetAll().Where(p=>p.ProfileType==ProfileType.Personal);
            return View(list);
        }

        public ActionResult CompanyProfiles()
        {
            var list = _profile.GetAll().Where(p => p.ProfileType == ProfileType.Company);
            return View(list);
        }

        public ActionResult Create()
        {
            ViewBag.MainCategoryId = new SelectList(_mainCategory.GetAll(), "MainCategoryId", "Name");
            return View();
        }

    }
}