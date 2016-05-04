using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public bool login(string username, string password)
        {
            try {
                if (WebApplication1.globals.Global.data.get_admin(username).check_password(password)) { return true; }
                if (WebApplication1.globals.Global.data.get_student(username).check_password(password)) { return true; }
                if (WebApplication1.globals.Global.data.get_teacher(username).check_password(password)) { return true; }

                else { return false; }
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}