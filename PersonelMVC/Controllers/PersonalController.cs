using PersonelMVC.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelMVC.Controllers
{
    public class PersonalController : Controller
    {
        PersonalDBEntities db = new PersonalDBEntities();
        // GET: Personal
        public ActionResult Index()
        {
            var model = db.Personal.ToList();
            return View(model);
        }
    }
}