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
    }
}