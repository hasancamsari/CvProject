using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvProject.Models;
using CvProject.Models.Entity;

namespace CvProject.Controllers
{
    public class MainPageController : Controller
    {
        CvProjectEntities3 db = new CvProjectEntities3();
        // GET: MainPage
        public ActionResult Index()
        {
            var model = new AllData
            {
                HomeData = db.TBLMAIN.ToList(),
                AboutData = db.TBLABOUT.ToList(),
                SkillsData = db.TBLSKILLS.ToList(),
                WorksData = db.TBLPROJECTS.ToList(),
                ContactData = db.TBLCONTACT.ToList()
            };
            return View(model);
        }

        public ActionResult Home()
        {
            var deger = db.TBLMAIN.ToList();
            return View(deger);
        }

        public ActionResult About()
        {
            var degerler = db.TBLABOUT.ToList();
            return View(degerler);
        }

        public ActionResult Skills()
        {
            var deger = db.TBLSKILLS.ToList();
            return View(deger);
        }

        public ActionResult Works()
        {
            var deger = db.TBLPROJECTS.ToList();
            return View(deger);
        }

        public ActionResult Contact()
        {
            var deger = db.TBLCONTACT.ToList();
            return View(deger);
        }

        public ActionResult Scripts()
        {
            return View();
        }

        public ActionResult Footer()
        {
            return View();
        }

        public ActionResult Header()
        {
            return View();
        }
    }
}