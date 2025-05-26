using System.Linq;
using System.Web.Mvc;
using CvProject.Models.Entity;
using System.Data.Entity;

namespace CvProject.Controllers
{
    public class TheMainPageController : Controller
    {
        CvProjectEntities3 db = new CvProjectEntities3();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Header()
        {
            return PartialView();
        }

        public ActionResult Home()
        {
            var values = db.TBLMAIN.FirstOrDefault(m => m.M_ACTIVE == 1);
            return PartialView(values);
        }

        public ActionResult About()
        {
            var values = db.TBLABOUT.Include(m => m.TBLITEM).Where(m=>m.A_ACTIVE == 1).ToList();
            return PartialView(values);
        }

        public ActionResult Skills()
        {
            var values = db.TBLSKILLS.Include(m => m.TBLITEM).Where(m => m.S_ACTIVE == 1).ToList();
            return PartialView(values);
        }

        public ActionResult Works()
        {
            var values = db.TBLPROJECTS.Include(m => m.TBLITEM).Where(m => m.P_ACTIVE == 1).ToList();
            return PartialView(values);
        }

        public ActionResult Contact()
        {
            var values = db.TBLCONTACT.ToList();
            return PartialView(values);
        }

        public ActionResult Footer()
        {
            var values = db.TBLMAIN.FirstOrDefault();
            return PartialView(values);
        }

        public ActionResult Scripts()
        {
            return PartialView();
        }
    }
}
