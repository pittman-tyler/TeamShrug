using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class CourseSearchController : Controller
    {
        // GET: CourseSearch
        public ActionResult Index()
        {
            return View();
        }

        public string CourseSearch(string id)
        {
            return WebApplication1.globals.Global.data.search_for_courses(id);
        }

        public string UserSearch(string id)
        {
            return WebApplication1.globals.Global.data.search_for_courses(id);
        }
    }
}