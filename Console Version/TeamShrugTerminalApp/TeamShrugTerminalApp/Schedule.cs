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
        List<Course> courseList;

        public Schedule()
        {
            courseList = new List<Course>(0);
            num_hours = 0;
        }

        public string display_courses()
        {
            string output = "";
            for (int element = 0; this.courseList.Count > element; element++)
            {
                output += this.courseList[element].ToString() + "\n";
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
                this.courseList.Add(a);
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
            for (int element = 0; element < courseList.Count; element++)
            {
                if (courseList[element].get_course_id() == a.get_course_id())
                    {
                    num_hours -= this.courseList[element].get_credit_hours();
                    this.courseList.RemoveAt(element);
                    }
            }
        }
    }
}