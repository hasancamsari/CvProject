using System.Linq;
using System.Web.Mvc;
using CvProject.Models.Entity;

namespace CvProject.Controllers
{
    public class AdminMainController : Controller
    {
        CvProjectEntities3 db = new CvProjectEntities3();

        // GET: AdminMain
        public ActionResult Index()
        {
            var veriler = db.TBLMAIN.ToList();
            return View(veriler);
        }

        [HttpGet]
        public ActionResult AddMain()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMain(TBLMAIN p1)
        {
            if (!ModelState.IsValid)
            {
                return View(p1);
            }

            db.TBLMAIN.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult DeleteMain(int id)
        {
            var silinecek = db.TBLMAIN.Find(id);
            db.TBLMAIN.Remove(silinecek);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Take(int id)
        {
            var guncellenecek = db.TBLMAIN.Find(id);
            return View(guncellenecek);
        }

        [HttpPost]
        public ActionResult UpdateMain(TBLMAIN p1)
        {
            var guncellenecek = db.TBLMAIN.Find(p1.MID);
            guncellenecek.NAME = p1.NAME;
            guncellenecek.DESCRIPTION = p1.DESCRIPTION;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Active(int id)
        {
            // Tüm kayıtları pasif yap
            foreach (var item in db.TBLMAIN)
            {
                item.M_ACTIVE = 0;
            }

            // Tıklanan kaydı aktif yap
            var aktif = db.TBLMAIN.Find(id);
            if (aktif != null)
            {
                aktif.M_ACTIVE = 1;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
