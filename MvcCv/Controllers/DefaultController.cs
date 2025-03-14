﻿using MvcCv.Models.Entity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    [AllowAnonymous] //Authorized ı bu sayfada devre dışı bırakmak için kullandık
    public class DefaultController : Controller
    {
        DbMvcCvEntities db = new DbMvcCvEntities();
        // GET: Default
        public ActionResult Index()
        {
            var value = db.Abouts.ToList();
            return View(value);
        }
        public PartialViewResult Experience()
        {
            var values = db.Experiences.ToList();
            return PartialView(values);
        }
        public PartialViewResult Education()
        {
            var values = db.Educations.ToList();
            return PartialView(values);
        }
        public PartialViewResult Talent()
        {
            var values = db.Talents.ToList();
            return PartialView(values);
        }
        public PartialViewResult Hobby()
        {
            var values = db.Hobbies.ToList();
            return PartialView(values);
        }
        public PartialViewResult Certificates()
        {
            var values = db.Awards.ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(Contact c)
        {
            c.Date = DateTime.Now;
            db.Contacts.Add(c);
            db.SaveChanges();
            return PartialView();
        }
        public PartialViewResult SocialMedia()
        {
            var values = db.SocialMedias.Where(x=>x.Status==true).ToList();
            return PartialView(values);
        }
    }
}