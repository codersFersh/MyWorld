using MyWorldEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWorldFront.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        private MyWorldDbContent db = new MyWorldDbContent();

        public ActionResult Login()
        {
            return View();
        }
    }
}