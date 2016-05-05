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
            return "Success!"
        }
    }
}
