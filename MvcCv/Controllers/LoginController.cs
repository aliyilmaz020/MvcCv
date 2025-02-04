using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        DbMvcCvEntities db = new DbMvcCvEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin a)
        {
            string username = a.Username;
            string password = a.Password;
            var isLogin = db.Admins.Any(x=>x.Username==username && x.Password==password);
            if (isLogin)
            {
                FormsAuthentication.SetAuthCookie(username,false);
                Session["Username"] = username;
                return RedirectToAction("Index","About");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}