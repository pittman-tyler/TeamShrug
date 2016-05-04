using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Course
    {
        protected string courseID { get; set; }
        protected string courseName { get; set; }
        protected string description { get; set; }
        protected string teacherName { get; set; }
        protected int meetingDays { get; set; }
        protected int creditHours { get; set; }
        protected int classTime { get; set; }
        protected int currentSize { get; set; }
        protected int maxSize { get; set; }
        protected List<string> roster { get; set; }

        public Course() { }

        public Course(string courseIDin, string nameIn, string descriptionIn, string teacherNameIn, int meetingDaysIn, int creditHoursIn, int timeIn,
            int maxSizeIn)
        {
            courseID = courseIDin;
            courseName = nameIn;
            description = descriptionIn;
            teacherName = teacherNameIn;
            meetingDays = meetingDaysIn;
            creditHours = creditHoursIn;
            classTime = timeIn;
            maxSize = maxSizeIn;
            currentSize = 0;
        }

        public string toString()
        {
            string output = "CourseID: " + courseID + "\nCourse Name: " + courseName + "\nDescription: " + description + "\nTeacher: " + teacherName;
            output += "\nCredit Hours: " + creditHours + "\nMax Size: " + maxSize + "\nCurrent Size: " + currentSize;

                return output;
        }

        public string get_course_id()
        {
            return courseID;
        }

        public int add_student(Student studentIN)
        {
            if(this.maxSize == this.currentSize)
            {
                return -1;
            }
            else
            {
                string name = studentIN.get_name();
                this.roster.Add(name);
                this.currentSize++;
                return 0;
            }
            
        }

        public string get_course_name()
        {
            return this.courseName;
        }

        public string get_course_description()
        {
            return this.description;
        }

        public string get_teacher_name()
        {
            return this.teacherName;
        }

        public int get_meeting_info()
        {
            return this.meetingDays;
        }
        
        public int get_credit_hours()
        {
            return this.creditHours;
        }

        public int get_time()
        {
            return this.classTime;
        }

        public int get_max_size()
        {
            return this.maxSize;
        }

        public int get_current_size()
        {
            return this.currentSize;
        }

    }
}
