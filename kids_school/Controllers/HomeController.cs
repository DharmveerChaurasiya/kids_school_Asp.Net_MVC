using kids_school.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kids_school.Controllers
{
    public class homeController : Controller
    {

        kiddbEntities db = new kiddbEntities();

        kiddbEntities2 db1 = new kiddbEntities2();  

        // GET: home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Classes()
        {
            return View();
        }
        public ActionResult Teachers()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(query q)
        {
            if (ModelState.IsValid == true)
            {
                db1.queries.Add(q);
                int a = db1.SaveChanges();
                if (a > 0)
                {
                    ViewBag.InsertMessage = "<script>alert('Details send successfully')</script>";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Details not send successfully')</script>";
                }
            }
            return View();
        }
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(kidtable u)
        {
            var kidtable = db.kidtables.Where(model => model.email == u.email && model.password == u.password).FirstOrDefault();
            if (kidtable != null)
            {
                Session["UserId"] = kidtable.id.ToString();
                Session["Email"] = kidtable.email.ToString();
                Session["Name"] = kidtable.name.ToString();
                TempData["LoginSuccessMessage"] = "<script>alert('Login Successfully ')</script>";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "<script>alert('Email or Password is incorrect ')</script>";
                return View();
            }

        }

        public ActionResult Logout()
        {
            Session.Abandon();  
            return RedirectToAction("Index","Home");
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(kidtable u)
        {
            if (ModelState.IsValid == true)
            {
                db.kidtables.Add(u);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.InsertMessage = "<script>alert('Register successfully')</script>";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Registration failed')</script>";
                }
            }
            return View();
        }

    }
}