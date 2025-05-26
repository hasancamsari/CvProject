using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvProject.Models;
using CvProject.Models.Entity;

namespace CvProject.Controllers
{
    public class AdminContactController : Controller
    {
        // GET: AdminContact
        CvProjectEntities3 db = new CvProjectEntities3();
        public ActionResult Index()
        {
            var deger = db.TBLCONTACT.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddContact(TBLCONTACT p1)
        {
            if (!ModelState.IsValid)
            {
                return View(p1);
            }
            db.TBLCONTACT.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteContact(int id)
        {
            var silinecek = db.TBLCONTACT.Find(id);

            if (silinecek.C_ACTIVE == 1)
            {
                TempData["ErrorMessage"] = "Bu kayıt aktif durumda olduğu için silinemez!";
                return RedirectToAction("Index");
            }

            db.TBLCONTACT.Remove(silinecek);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Take(int id)
        {
            var guncellenecek = db.TBLCONTACT.Find(id);
            return View(guncellenecek);
        }

        [HttpPost]
        public ActionResult UpdateContact(TBLCONTACT p1)
        {
            var guncellenecek = db.TBLCONTACT.Find(p1.SMID);
            guncellenecek.PHONE = p1.PHONE;
            guncellenecek.SMLGIT = p1.SMLGIT;
            guncellenecek.LINKGIT = p1.LINKGIT;
            guncellenecek.SMLLINKED = p1.SMLLINKED;
            guncellenecek.LINKIN = p1.LINKIN;
            guncellenecek.LMAIL = p1.LMAIL;
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

            var skill = db.TBLCONTACT.Find(id);
            if (skill != null)
            {
                skill.C_ACTIVE = s_active;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}