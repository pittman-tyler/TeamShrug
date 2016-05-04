using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public void deleteUser(string UserID)
        {
            WebApplication1.globals.Global.data.delete_user(UserID);
        }

        public void createUser(User a)
        {
            WebApplication1.globals.Global.data.add_user(a);
        }
    }
}