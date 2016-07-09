using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Building.Web.Mvc.Controllers
{
    public partial class ErrorController : Controller
    {
        // GET: Error
        public virtual ActionResult NotFound()
        {
            return View();
        }

        public virtual ActionResult BadRequest()
        {
            return View();
        }
    }
}