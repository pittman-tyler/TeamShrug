using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class TranscriptController : Controller
    {
        // GET: Transcript
        public ActionResult Index()
        {
            return View();
        }

        public void updateGrade(int gradeIn, string teacherID, string studentID, string courseID)
        {
            Course a = WebApplication1.globals.Global.data.get_course(courseID);
            Student b = WebApplication1.globals.Global.data.get_student(studentID);
            WebApplication1.globals.Global.data.get_teacher(teacherID).assignGrade(a, b, gradeIn);
        }
    }
}