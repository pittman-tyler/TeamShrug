﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamShrugTerminalApp
{
    public class Course
    {
        protected string courseID { get; set; }
        protected string courseName { get; set; }
        protected string description { get; set; }
        protected string teacherID { get; set; }
        protected int meetingDays { get; set; }
        protected int creditHours { get; set; }
        protected int classTime { get; set; }
        protected int currentSize { get; set; }
        protected int maxSize { get; set; }
        protected List<Student> roster { get; set; }

        public Course() { }

        public Course(string courseIDin, string nameIn, string descriptionIn, string teacherNameIn, int meetingDaysIn, int creditHoursIn, int timeIn,
            int maxSizeIn)
        {
            courseID = courseIDin;
            courseName = nameIn;
            description = descriptionIn;
            teacherID = teacherNameIn;
            meetingDays = meetingDaysIn;
            creditHours = creditHoursIn;
            classTime = timeIn;
            maxSize = maxSizeIn;
            currentSize = 0;
            roster = new List<Student>(0);
        }

        public string toString()
        {
            string output = "CourseID: " + courseID + "\nCourse Name: " + courseName + "\nDescription: " + description + "\nTeacher: " + teacherID;
            output += "\nCredit Hours: " + creditHours + "\nMax Size: " + maxSize + "\nCurrent Size: " + currentSize;

                return output;
        }

        internal string roster_view()
        {
            string output = "";
            for (int i = 0; i < roster.Count; i++)
            {
                output += "User ID: " + roster[i].get_username() + "\t Name: " + roster[i].get_name() + "\n";
            }
            if(string.Compare(output, "") == 0) { return "No students in this class."; }
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
                this.roster.Add(studentIN);
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
            return this.teacherID;
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

        internal int remove_student(string userID)
        {
            bool studentExists = false;
            for (int i = 0; i < roster.Count && studentExists == false; i++)
            {
                if(string.Compare(roster[i].get_username(), userID, true) == 0)
                {
                    roster.RemoveAt(i);
                    currentSize--;
                    studentExists = true;
                }
            }
            if(studentExists) { return 1; }
            else { return -1; }
        }
    }
}
