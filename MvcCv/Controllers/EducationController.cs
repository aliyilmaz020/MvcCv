using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        GenericRepository<Education> repo = new GenericRepository<Education>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(Education e)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEducation");
            }
            repo.TAdd(e);
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
        public ActionResult Edit(Education e)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }
            var value = repo.TGet(e.ID);
            value.Title = e.Title;
            value.SubTitle = e.SubTitle;
            value.SubTitle2 = e.SubTitle2;
            value.GPA = e.GPA;
            value.Date = e.Date;
            repo.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}