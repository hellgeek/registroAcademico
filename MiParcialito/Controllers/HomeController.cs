using MiParcialito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiParcialito.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new cc104809Entities())
            {
                var cursos = db.cursos.Include("docentes").ToList();
                return View(cursos);
            }
        }

        public ActionResult HomeWelcome()
        {            
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}