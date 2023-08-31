﻿using MiParcialito.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using BCrypt.Net;

namespace MiParcialito.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string user, string password)
        {
            try
            {
                using (cc104809Entities db = new cc104809Entities())
                {
                    var lst = from d in db.user
                              where d.email == user && d.idStatus == 1
                              select d;

                    if (BCrypt.Net.BCrypt.Verify(password, lst.First().password))
                    {
                        user oUser = lst.First();

                        Session["User"] = oUser;

                        Session["UserAdmin"] = (oUser.idroles == 1);

                        
                        Session["Usuario"] = oUser.idUser;

                        return Content("1");
                    }
                    else
                    {
                        return Content("Credenciales no válidas, ingrese otras");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("Error de aplicación: " + ex.Message);
            }
        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("index", "Home");
        }
    }
}