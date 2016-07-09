using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Context;
using DomainClasses.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Building.Web.Mvc.Areas.Admin.Controllers
{
    public partial class RoleController : Controller
    {
        ApplicationDbContext context;

        public RoleController()
        {
            context = new ApplicationDbContext();
        }

        /// <summary>
        /// Get All Roles
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult Index()
        {
            var roles = context.Roles.ToList();
            return View(roles);
        }

        public virtual ActionResult Details(string id)
        {
            if (id == null)
            {
                return RedirectToAction("BadRequest", "Error", new { area = "" });
            }
            var unit = context.Roles.Find(id);
            if (unit == null)
            {
                return RedirectToAction("NotFound", "Error", new { area = "" });
            }
            return View(unit);
        }


        /// <summary>
        /// Create  a New role
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        /// <summary>
        /// Create a New Role
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult Create(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public virtual ActionResult Edit(string id)
        {
            if (id == null)
            {
                return RedirectToAction("BadRequest", "Error", new { area = "" });
            }
            var unit = context.Roles.Find(id);
            if (unit == null)
            {
                return RedirectToAction("NotFound", "Error", new { area = "" });
            }
            return View(unit);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit([Bind(Include = "Name,Id")] IdentityRole Role)
        {
            if (ModelState.IsValid)
            {
                context.Roles.AddOrUpdate(Role);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Role);
        }


        public virtual ActionResult Delete(string id)
        {
            if (id == null)
            {
                return RedirectToAction("BadRequest", "Error", new { area = "" });
            }
            var unit = context.Roles.Find(id);
            if (unit == null)
            {
                return RedirectToAction("NotFound", "Error", new { area = "" });
            }
            return View(unit);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(string id)
        {
            var unit = context.Roles.Find(id);
            context.Roles.Remove(unit);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public virtual ActionResult Grid()
        {

            var roles = context.Roles.Select(r => r.Name);


            return Json(new { draw = 1, recordsTotal = 3, recordsFiltered = 3, data = roles }, JsonRequestBehavior.AllowGet);
        }
    }
}