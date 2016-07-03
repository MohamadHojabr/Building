using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.Context;
using ServiceLayer.IService;

namespace Building.Web.Mvc.Areas.Admin.Controllers
{
    public class AddressController : Controller
    {
        // GET: Admin/Address
        private IUnitOfWork _uow;
        private IAddress _address;

        public AddressController(IUnitOfWork uow, IAddress address)
        {
            _uow = uow;
            _address = address;
        }

        public ActionResult Index()
        {
            var list = _address.GetAll();
            return View(list);
        }
    }
}