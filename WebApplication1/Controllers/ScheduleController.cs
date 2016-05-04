using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ScheduleController : Controller
    {
        // GET: Schedule
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetStudentSchedule(string userID)
        {
            Student a = WebApplication1.globals.Global.data.get_student(userID);
            a.get_student_transcript();
            return View();
        }

        public void AddCourse(string CourseID, string userID)
        {
            Course a = WebApplication1.globals.Global.data.get_course(CourseID);
            globals.Global.data.get_student(userID).schedule.add_course(a);
            
        }

        public void DropCourse(string CourseID, string userID)
        {
            Course a = globals.Global.data.get_course(CourseID);
            globals.Global.data.get_student(userID).schedule.drop_course(a);
        }
    }
}