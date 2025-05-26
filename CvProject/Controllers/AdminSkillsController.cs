using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvProject.Models;
using CvProject.Models.Entity;

namespace CvProject.Controllers
{
    public class AdminSkillsController : Controller
    {
        // GET: AdminSkills
        CvProjectEntities3 db = new CvProjectEntities3();
        public ActionResult Index()
        {
            var deger = db.TBLSKILLS.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult AddSkills()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSkills(TBLSKILLS p1)
        {
            if (!ModelState.IsValid)
            {
                return View(p1);
            }
            db.TBLSKILLS.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkills(int id)
        {
            var silinecek = db.TBLSKILLS.Find(id);

            if (silinecek.S_ACTIVE == 1)
            {
                TempData["ErrorMessage"] = "Bu kayıt aktif durumda olduğu için silinemez!";
                return RedirectToAction("Index");
            }

            db.TBLSKILLS.Remove(silinecek);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Take(int id)
        {
            var guncellenecek = db.TBLSKILLS.Find(id);
            return View(guncellenecek);
        }

        [HttpPost]
        public ActionResult UpdateSkills(TBLSKILLS p1)
        {
            var guncellenecek = db.TBLSKILLS.Find(p1.SID);
            guncellenecek.SKILLS = p1.SKILLS;
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

            var skill = db.TBLSKILLS.Find(id);
            if (skill != null)
            {
                skill.S_ACTIVE = s_active;
                db.SaveChanges();
            }

            return RedirectToAction("Index"); // veya Ajax için uygun response
        }

    }
}