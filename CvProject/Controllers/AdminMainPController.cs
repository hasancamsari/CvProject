using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvProject.Models;
using CvProject.Models.Entity;

namespace CvProject.Controllers
{
    public class AdminMainPController : Controller
    {
        // GET: AdminMainP
        CvProjectEntities3 db = new CvProjectEntities3();
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

        public ActionResult MainPage_A()
        {
            return View();
        }
    }
}