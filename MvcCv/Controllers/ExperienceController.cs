using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository repo = new ExperienceRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(Experience e)
        {
            repo.TAdd(e);
            return RedirectToAction("Index");
        }
        public ActionResult Remove(Experience e)
        {   
            var value = repo.TGet(e.ID);
            repo.TRemove(value);
            return RedirectToAction("Index");
        }
        public ActionResult GetExperience(int id)
        {
            var value = repo.TGet(id);
            return View(value);
        }
        public ActionResult Edit(Experience e)
        {
            var updateValue = repo.TGet(e.ID);
            updateValue.Title = e.Title;
            updateValue.Description = e.Description;
            updateValue.SubTitle = e.SubTitle;
            updateValue.Date = e.Date;
            repo.TUpdate(updateValue);
            return RedirectToAction("Index");
        }
    }
}