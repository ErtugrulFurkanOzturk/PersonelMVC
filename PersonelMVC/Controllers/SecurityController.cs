using PersonelMVC.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PersonelMVC.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        PersonalDBEntities db = new PersonalDBEntities();
        // GET: Security
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var userInDb = db.User.FirstOrDefault(a=>a.TCIdentityNumber==user.TCIdentityNumber && a.Password==user.Password);
            if (userInDb!=null)
            {
                FormsAuthentication.SetAuthCookie(userInDb.TCIdentityNumber.ToString(),false);
                return RedirectToAction("Index","Departman");
            }
            else
            {
                ViewBag.Message = "Wrong TC Identity number or Password";
                return View();
            }
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}