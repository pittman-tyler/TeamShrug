using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Database
    {
        //Fields to be used by the database
        List<User> listUsers;
        List<Course> courseList;

        //Populates a temporary database to be used throughout the program.
        public Database()
        {
            Student a = new Student("Aubie", "AU0001", "WDE", true);
            Administrator b = new Administrator("Jay Gouge", "JG0001", "President");
            Teacher c = new Teacher("Tony Teacher", "TT0001", "password");
            Course d = new Course("COMP 3700", "Software Modeling and Design", "Something goes here", "Yilmaz", 2, 3, 1230, 45);
            Teacher e = new Teacher("Yilmaz", "yilmaz", "password");
            Course f = new Course("COMP 3500", "Operating Systems", "Let's learn OSes", "Tony Teacher", 1, 3, 0900, 45);
            listUsers.Add(a);
            listUsers.Add(b);
            listUsers.Add(c);
            listUsers.Add(e);
            courseList.Add(d);
            courseList.Add(f);
        }

        //When you search for a user, you get a string of user information, separated by new lines.
        public string search_for_users(string param)
        {
            string userList = "";
            for(int i = 0; i < listUsers.Count(); i++)
            {
                if (String.Compare(listUsers[i].get_username(), param, true) == 0)
                {
                    userList += listUsers[i].toString() + "\n";
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
                    listOfCourses += listUsers[i].toString();
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
            listUsers.Add(input);
        }
    }
}
