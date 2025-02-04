using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        GenericRepository<SocialMedia> repo = new GenericRepository<SocialMedia>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(SocialMedia s)
        {
            repo.TAdd(s);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var media = repo.TGet(id);
            return View(media);
        }
        [HttpPost]
        public ActionResult Edit(SocialMedia s)
        {
            var media = repo.TGet(s.ID);
            media.Name = s.Name;
            media.Link = s.Link;
            media.Icon = s.Icon;
            media.Status = true;
            repo.TUpdate(media);
            return RedirectToAction("Index");
        }
        public ActionResult Remove(int id)
        {
            var value = repo.TGet(id);
            value.Status = false;
            repo.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}