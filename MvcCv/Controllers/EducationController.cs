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
            if(!ModelState.IsValid)
            {
                return View("AddEducation");
            }
            repo.TAdd(e);
            return RedirectToAction("Index");
        }
    }
}