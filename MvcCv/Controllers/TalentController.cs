using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class TalentController : Controller
    {
        // GET: Talent
        TalentRepository repo = new TalentRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddTalent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTalent(Talent t)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("AddTalent");
            //}
            repo.TAdd(t);
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
        public ActionResult Edit(Talent t)
        {
            var updateTalent = repo.TGet(t.ID);
            updateTalent.TalentName = t.TalentName;
            updateTalent.TalentPercent = t.TalentPercent;
            repo.TUpdate(updateTalent);
            return RedirectToAction("Index");
        }
    }
}