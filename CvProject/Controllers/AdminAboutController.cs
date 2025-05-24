using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using CvProject.Models;
using CvProject.Models.Entity;

namespace CvProject.Controllers
{
    public class AdminAboutController : Controller
    {
        // GET: AdminAbout
        CvProjectEntities3 db = new CvProjectEntities3();
        public ActionResult Index()
        {
            var deger = db.TBLABOUT.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAbout(TBLABOUT p1)
        {
            if (!ModelState.IsValid)
            {
                return View(p1);
            }
            db.TBLABOUT.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAbout(int id)
        {
            var silinecek = db.TBLABOUT.Find(id);

            if (silinecek.A_ACTIVE == 1)
            {
                TempData["ErrorMessage"] = "Bu kayıt aktif durumda olduğu için silinemez!";
                return RedirectToAction("Index");
            }

            db.TBLABOUT.Remove(silinecek);
            db.SaveChanges();

            return RedirectToAction("Index");
        }



        public ActionResult Take(int id)
        {
            var guncellenecek = db.TBLABOUT.Find(id);
            return View(guncellenecek);
        }

        [HttpPost]
        public ActionResult UpdateAbout(TBLABOUT p1)
        {
            var guncellenecek = db.TBLABOUT.Find(p1.AID);
            guncellenecek.DESCRIPTION_AB = p1.DESCRIPTION_AB;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Active(int id)
        {
            // Tüm kayıtları pasif yap
            foreach (var item in db.TBLABOUT)
            {
                item.A_ACTIVE = 0;
            }

            // Tıklanan kaydı aktif yap
            var aktif = db.TBLABOUT.Find(id);
            if (aktif != null)
            {
                aktif.A_ACTIVE = 1;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}