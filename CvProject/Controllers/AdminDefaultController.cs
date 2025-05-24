using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CvProject.Models;
using CvProject.Models.Entity;

namespace CvProject.Controllers
{
    public class AdminDefaultController : Controller
    {
        // GET: AdminDefault
        CvProjectEntities3 db = new CvProjectEntities3();
        public ActionResult Index()
        {
            var degerler = db.TBLMAIN.ToList();
            return PartialView(degerler);
        }

        public ActionResult HeaderP()
        {
            return PartialView();
        }
        public ActionResult SidebarP()
        {
            return PartialView();
        }
        public ActionResult NavbarP()
        {
            var deger = db.TBLMAIN.FirstOrDefault();
            return PartialView(deger);
        }

        public ActionResult FooterP()
        {
            return PartialView();
        }

        public ActionResult ScriptsP()
        {
            return PartialView();
        }
    }
}