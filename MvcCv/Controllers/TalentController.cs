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
    }
}