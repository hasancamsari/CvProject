using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvProject.Models;
using CvProject.Models.Entity;

namespace CvProject.Controllers
{
    public class AdminWorksController : Controller
    {
        // GET: AdminWorks
        CvProjectEntities3 db = new CvProjectEntities3();
        public ActionResult Index()
        {
            var deger = db.TBLPROJECTS.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult AddWorks()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddWorks(TBLPROJECTS p1)
        {
            if (!ModelState.IsValid)
            {
                return View(p1);
            }
            db.TBLPROJECTS.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteWorks(int id)
        {
            var silinecek = db.TBLPROJECTS.Find(id);

            if (silinecek.P_ACTIVE == 1)
            {
                TempData["ErrorMessage"] = "Bu kayıt aktif durumda olduğu için silinemez!";
                return RedirectToAction("Index");
            }

            db.TBLPROJECTS.Remove(silinecek);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Take(int id)
        {
            var guncellenecek = db.TBLPROJECTS.Find(id);
            return View(guncellenecek);
        }

        [HttpPost]
        public ActionResult UpdateWorks(TBLPROJECTS p1)
        {
            var guncellenecek = db.TBLPROJECTS.Find(p1.PID);
            guncellenecek.JOBS = p1.JOBS;
            guncellenecek.WORKS = p1.WORKS;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Active(int id, string activeCheckbox)
        {
            // activeCheckbox checkbox'ın gönderilen değeri olacak:
            // checked ise "1"
            // unchecked ise "0" (hidden input)
            int s_active = activeCheckbox == "1" ? 1 : 0;

            var skill = db.TBLPROJECTS.Find(id);
            if (skill != null)
            {
                skill.P_ACTIVE = s_active;
                db.SaveChanges();
            }

            return RedirectToAction("Index"); // veya Ajax için uygun response
        }
    }
}