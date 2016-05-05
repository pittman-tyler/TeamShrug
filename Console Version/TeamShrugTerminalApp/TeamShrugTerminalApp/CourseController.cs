using System;

namespace TeamShrugTerminalApp
{
    internal class CourseController
    {
        internal static string addCourse(string courseName, string courseDescription, string courseHours, string courseID, string teacherID, string meetingDays, string creditHours, string classTime, string maxSize, Database db)
        {
            if(db.get_course(courseID) == null) { return "Course already exists. Please try again"; }
            else
            {
                int hours = Int32.Parse(courseHours);
                if (0 > hours || 4 < hours) { return "Invalid credit hours. Please try again."; }
                int days = Int32.Parse(meetingDays);
                if(0 >= days || 3 <= days) { return "Invalid set of days. Please try again."; }
                int time = Int32.Parse(classTime);
                if(4 > time || time > 7) { return "Invalid time. Please try again."; }
                int max = Int32.Parse(maxSize);

                if(db.get_teacher(teacherID) == null) { return "This teacher does not exist. Please either create the teacher or enter a valid user ID."; }
                Course temp = new Course(courseID, courseName, courseDescription, teacherID, days, hours, time, max);
                if (db.get_teacher(teacherID).getSchedule().add_course(temp) == -1) { return "This teacher already is teaching the maximum number of classes."; }
               
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
            if(db.get_course(selection) == null) { return "Course does not exist."; }
            return db.get_course(selection).roster_view();
        }
    }
}