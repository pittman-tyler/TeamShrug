using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamShrugTerminalApp
{
    public class Database
    {
        //Fields to be used by the database
        public List<Student> listStudents;
        public List<Administrator> listAdmins;
        public List<Teacher> listTeachers;
        public List<Course> courseList;



        //Populates a temporary database to be used throughout the program.
        public Database()
        {
            listStudents = new List<Student>(0);
            listAdmins = new List<Administrator>(0);
            listTeachers = new List<Teacher>(0);
            courseList = new List<Course>(0);

            Student a = new Student("Aubie", "AU0001", "WDE", true);
            Administrator b = new Administrator("Jay Gouge", "JG0001", "President");
            Administrator g = new Administrator("admin", "admin", "password");
            Teacher c = new Teacher("Tony Teacher", "TT0001", "password");
            Teacher h = new Teacher("Teacher", "teacher", "password");
            Student i = new Student("student", "student", "password", true);
            Course d = new Course("COMP 3700", "Software Modeling and Design", "Something goes here", "Yilmaz", 2, 3, 1230, 45);
            Teacher e = new Teacher("Yilmaz", "yilmaz", "password");
            Course f = new Course("COMP 3500", "Operating Systems", "Let's learn OSes", "Tony Teacher", 1, 3, 0900, 45);

            listStudents.Add(a);
            listAdmins.Add(b);
            listTeachers.Add(c);
            listTeachers.Add(e);
            courseList.Add(d);
            courseList.Add(f);
            listAdmins.Add(g);
            listStudents.Add(i);
            listTeachers.Add(h);
        }

        internal void delete_course(string courseID)
        {
            for (int i = 0; i < courseList.Count; i++)
            {
                if(string.Compare(courseList[i].get_course_id(), courseID, true) == 0)
                {
                    courseList.RemoveAt(i);
                }
            }
        }

        internal string enrollmentSummary()
        {
            string output = "";
            for(int i = 0; i < listStudents.Count; i++)
            {
                output += listStudents[i].toString() + "\n\n";
            }
            return output + "\n Total Number Enrolled: " + listStudents.Count;

        }

        internal void delete_user(string userID)
        {
            for(int i = 0; i < listStudents.Count; i++)
            {
                if(listStudents[i].get_username() == userID)
                {
                    listStudents.RemoveAt(i);
                }
            }
            for (int i = 0; i < listTeachers.Count; i++)
            {
                if (listTeachers[i].get_username() == userID)
                {
                    listTeachers.RemoveAt(i);
                }
            }
            for (int i = 0; i < listAdmins.Count; i++)
            {
                if (listAdmins[i].get_username() == userID)
                {
                    listAdmins.RemoveAt(i);
                }
            }
        }

        public Teacher get_teacher(string teacherID)
        {
            Teacher a = null;
            for (int i = 0; i < listTeachers.Count; i++)
            {
                
                if (listTeachers[i].get_username() == teacherID)
                {
                    a = listTeachers[i];
                }
                            }
            return a;
        }

        public Course get_course(string courseID)
        {
            Course a = null;
            for (int i = 0; i < courseList.Count; i++) {
                if (courseList[i].get_course_id() == courseID)
                {
                    a = courseList[i];
                }
            }
            return a;
        }

        public Student get_student(string username)
        {
            Student a = null;
            for (int i = 0; i < listStudents.Count; i++)
            {
                if (String.Compare(listStudents[i].get_username(), username, true) == 0)
                {
                    a = listStudents[i];
                }

            }

            return a;
        }

        public Administrator get_admin(string username)
        { 
        Administrator a = null;
            for (int i = 0; i<listAdmins.Count; i++)
            {
                if (String.Compare(listAdmins[i].get_username(), username, true) == 0)
                {
                    a = listAdmins[i];
                }

}
            return a;
        }

        //When you search for a user, you get a string of user information, separated by new lines.
        public string search_for_users(string param)
        {
            string userList = "";
            for(int i = 0; i < listStudents.Count(); i++)
            {
                if (String.Compare(listStudents[i].get_username(), param, true) == 0)
                {
                    userList += listStudents[i].toString() + "\n";
                }
            }
            for (int i = 0; i < listAdmins.Count(); i++)
            {
                if (String.Compare(listAdmins[i].get_username(), param, true) == 0)
                {
                    userList += listAdmins[i].toString() + "\n";
                }
            }
            for (int i = 0; i < listTeachers.Count(); i++)
            {
                if (String.Compare(listTeachers[i].get_username(), param, true) == 0)
                {
                    userList += listTeachers[i].toString() + "\n";
                }
            }
            if (userList.Equals("")){
                return "No Results Found";
            }
            else
            {
                return userList;
            }
        }

        //When you search for a user, you get a string of course information, separted by new lines.
        public string search_for_courses(string param)
        {
            string listOfCourses = "";
            for (int i = 0; i < courseList.Count(); i++)
            {
                if (String.Compare(courseList[i].get_course_id(), param, true) == 0)
                {
                    listOfCourses += courseList[i].toString();
                }
            }
            if (listOfCourses.Equals(""))
            {
                return "No Results Found";
            }
            else
            {
                return listOfCourses;
            }
        }

        //Adds a course to the "Database"
        public void add_course(Course input)
        {
            courseList.Add(input);
        }

        //Adds a user to the "Database"
        public void add_user(User input)
        {
            for (int i = 0; i < listStudents.Count; i++)
            {
                if (listStudents[i].get_username() == input.get_username())
                {
                    throw new Exception("Username already exists");
                }
            }
            for (int i = 0; i < listTeachers.Count; i++)
            {
                if (listTeachers[i].get_username() == input.get_username())
                {
                    throw new Exception("Username already exists");
                }
            }
            for (int i = 0; i < listAdmins.Count; i++)
            {
                if (listAdmins[i].get_username() == input.get_username())
                {
                    throw new Exception("Username already exists");
                }
            }
            if (input is Student){
                listStudents.Add((Student)input);
            }
            if(input is Administrator)
            {
                listAdmins.Add((Administrator)input);
            }
            if(input is Teacher)
            {
                listTeachers.Add((Teacher)input);
            }
        }
    }
}
