using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class CertificateController : Controller
    {
        // GET: Certificate
        GenericRepository<Award> repo = new GenericRepository<Award>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var value = repo.TGet(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult Edit(Award a)
        {
            var award = repo.TGet(a.ID);
            award.Description = a.Description;
            award.Date = a.Date;
            repo.TUpdate(award);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddCertificate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCertificate(Award a)
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
    }
}