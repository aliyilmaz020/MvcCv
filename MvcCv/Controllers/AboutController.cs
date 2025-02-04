using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutRepository repo = new AboutRepository();
        [HttpGet]
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(About a)
        {
            var value = repo.TGet(a.ID);
            value.Name = a.Name;
            value.Surname = a.Surname;
            value.Description = a.Description;
            value.Address = a.Address;
            value.Phone = a.Phone;
            value.Mail = a.Mail;
            value.Image = a.Image;
            repo.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}