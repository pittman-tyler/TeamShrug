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

        public string CourseSearch(string id)
        {
            return WebApplication1.globals.Global.data.search_for_users(id);
        }

        public string UserSearch(string id)
        {
            return "<p>" + WebApplication1.globals.Global.data.search_for_users(id) + "</p>";
        }
    }
}
