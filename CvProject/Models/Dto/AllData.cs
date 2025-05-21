using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CvProject.Models.Entity;

namespace CvProject.Models
{
    public class AllData
    {
        public List<TBLMAIN> HomeData { get; set; }
        public List<TBLABOUT> AboutData { get; set; }
        public List<TBLSKILLS> SkillsData { get; set; }
        public List<TBLPROJECTS> WorksData { get; set; }
        public List<TBLCONTACT> ContactData { get; set; }
    }
}