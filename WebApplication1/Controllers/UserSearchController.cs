using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class UserSearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserSearch(string id)
        {
            ViewBag.Message("<p>" + WebApplication1.globals.Global.data.search_for_users(id) + "</p>");
            return View();
        }
    }
}
