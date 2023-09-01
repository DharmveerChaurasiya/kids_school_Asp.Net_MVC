using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kids_school.Controllers
{
    public class CourcesController : Controller
    {
        // GET: Cources
        public ActionResult Art()
        {
            return View();
        }

        public ActionResult Language()
        {
            return View();
        }

        public ActionResult Science()
        {
            return View();
        }
    }
}