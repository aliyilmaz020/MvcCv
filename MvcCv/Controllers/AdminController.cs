using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<Admin> repo = new GenericRepository<Admin>();
        public ActionResult Index()
        {
            var list = repo.List();
            return View(list);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin a)
        {
            repo.TAdd(a);
            return RedirectToAction("Index");
        }
        public ActionResult Remove(int id)
        {
            var value = repo.TGet(id);
            repo.TRemove(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var value = repo.TGet(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult Edit(Admin a)
        {
            var value = repo.TGet(a.ID);
            value.Username = a.Username;
            value.Password = a.Password;
            repo.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}