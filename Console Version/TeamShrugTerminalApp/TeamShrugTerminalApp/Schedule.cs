using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamShrugTerminalApp
{
    public class Schedule
    {
        int MAX_HOURS = 18;
        int num_hours;
        List<Course> courses;

        public Schedule()
        {
            num_hours = 0;
        }

        public string display_courses()
        {
            string output = "";
            for (int element = 0; courses.Count > element; element++)
            {
                output += courses[element].ToString() + "\n";
            }
            return output;
        }

        public int get_num_hours()
        {
            return num_hours;
        }

        public int add_course(Course a)
        {
            if(a.get_credit_hours() + num_hours <= MAX_HOURS)
            {
                courses.Add(a);
                num_hours += a.get_credit_hours();
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public void drop_course(Course a)
        {
            for (int element = 0; element < courses.Count; element++)
            {
                if (courses[element].get_course_id() == a.get_course_id())
                    {
                    num_hours -= courses[element].get_credit_hours();
                    courses.RemoveAt(element);
                    }
            }
        }
    }
}