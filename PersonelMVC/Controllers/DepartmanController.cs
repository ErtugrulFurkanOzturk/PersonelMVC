using PersonelMVC.Models;
using PersonelMVC.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelMVC.Controllers
{
    
    public class DepartmanController : Controller
    {
        // GET: Departman
        PersonalDBEntities db = new PersonalDBEntities();

        
        public ActionResult Index()
        {
            var model = db.Departman.ToList();

            return View(model);
        }
        [HttpGet]
        public ActionResult Newdepartman()
        {
            
            return View("NewDepartman",new Departman());
        }
        [HttpPost]
        public ActionResult Save(Departman departman)
        {
            if (!ModelState.IsValid)
            {
                return View("NewDepartman");
            }
            if (departman.Id==0)
            {
                db.Departman.Add(departman);
            }
            else
            {
                var updateDepartman = db.Departman.Find(departman.Id);
                if (updateDepartman==null)
                {
                    return HttpNotFound();
                }
                updateDepartman.DepartmanName = departman.DepartmanName;

            }
            db.SaveChanges();
           
            return RedirectToAction("Index","Departman");
        }

        public ActionResult Update(int id)
        {
            var model = db.Departman.Find(id);
            if (model==null)
            {
                return HttpNotFound();
            }
            return View("NewDepartman",model);
        }
        public ActionResult Delete(int id)
        {
            var deletedDepartman = db.Departman.Find(id);
            if (deletedDepartman==null)
            {
                return HttpNotFound();

            }
            db.Departman.Remove(deletedDepartman);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}