using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamShrugTerminalApp
{
    class StudentController
    {
        public static string changeRegistrationStatus(Database db, string userID, string regStatus)
        {
            if (db.get_student(userID) == null)
            {
                return "Student does not exist";
            }
            else
            {
                if(String.Compare(regStatus, "0") == 0)
                {
                    db.get_student(userID).set_registration_status(false);
                    return "Success!";
                }
                else if (String.Compare(regStatus, "1") == 0 )
                {
                    db.get_student(userID).set_registration_status(true);
                    return "Success!";
                }
                else
                {
                    return "Invalid Registration Status Input.";
                }
            }
        }

        internal static string create_student(string personName, string username, string password, string registrationStatus, Database db)
        {
            if (db.get_student(username) != null)
            {
                return "User already exists. Please choose another user name.";
            }
            else
            {
                bool regStatus;
                if (String.Compare(registrationStatus, "0") == 0) { regStatus = false; }
                else if(String.Compare(registrationStatus, "1") == 0) { regStatus = true; }
                else { return "Invalid value for registration status"; }
                Student temp = new Student(personName, username, password, regStatus);
                db.add_user(temp);
            }
            return "Success!";
        }

        internal static string get_student_list(Database db)
        {
            return db.enrollmentSummary();
        }

        internal static string update_grade(string selection, string selection3, string grade, Database db)
        {
            int gradeNum = Int32.Parse(grade);
            db.get_student(selection3).get_student_transcript().update_transcript(db.get_course(selection), gradeNum);
            return "Success!";
        }

        internal static string view_transcript(Database db, string loggedInUser)
        {
            return db.get_student(loggedInUser).get_student_transcript().toString();
        }

        internal static string add_course(string courseID, string userID, Database db)
        {
            if(db.get_course(courseID) == null) { return "Course does not exist. Please try again."; }
            else
            {
                Course temp = db.get_course(courseID);
                Student tempStud = db.get_student(userID);
                if (db.get_course(courseID).add_student(tempStud) == -1) { return "Course is full. Please try another course"; }

                if (db.get_student(userID).get_schedule().add_course(temp) == -1) { return "You are already taking the maximum number of alotted hours."; }

            }
            return "Success!";
        }

        internal static string drop_course(string selection, string loggedInUser, Database db)
        {
            if(db.get_course(selection) == null) { return "Course does not exist. Please try again."; }
            else if(db.get_course(selection).remove_student(loggedInUser) == -1) { return "Student was not part of the course."; }
            else
            {
                db.get_student(loggedInUser).get_schedule().drop_course(db.get_course(selection));
                return "Success!";
            }
            

        }
    }
}
