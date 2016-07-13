using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Building.Web.Mvc.Areas.Admin.Controllers
{
    public partial class ArticlesController : Controller
    {
        // GET: Admin/Articles
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}