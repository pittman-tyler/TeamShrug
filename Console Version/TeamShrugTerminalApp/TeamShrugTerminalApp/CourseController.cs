using System;

namespace TeamShrugTerminalApp
{
    internal class CourseController
    {
        internal static string addCourse(string courseName, string courseDescription, string courseHours, string courseID, string teacherName, string meetingDays, string creditHours, string classTime, string maxSize, Database db)
        {
            if(db.get_course(courseID) == null) { return "Course already exists. Please try again"; }
            else
            {
                int hours = Int32.Parse(courseHours);
                int days = Int32.Parse(meetingDays);
                int time = Int32.Parse(classTime);
                int max = Int32.Parse(maxSize);

                Course temp = new Course(courseID, courseName, courseDescription, teacherName, days, hours, time, max);
                db.add_course(temp);

                return "Success!";

            }
        }

        internal static string delete_course(string courseID, Database db)
        {
            if(db.get_course(courseID) == null) { return "Course selected could not be found, please try again."; }
            else
            {
                db.delete_course(courseID);
                return "Success!";
            }
        }

        internal static string view_students(string selection, Database db)
        {
            return db.get_course(selection).roster_view();
        }
    }
}