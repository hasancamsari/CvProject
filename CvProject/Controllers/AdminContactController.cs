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
    }
}