using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HobbyController : Controller
    {
        // GET: Hobby
        GenericRepository<Hobby> repo = new GenericRepository<Hobby>();
        [HttpGet]
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(Hobby h)
        {
            var value = repo.TGet(h.ID);
            value.Description = h.Description;
            value.Description2 = h.Description2;
            repo.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}